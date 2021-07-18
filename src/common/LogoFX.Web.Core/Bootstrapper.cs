using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.Http.Dispatcher;
using LogoFX.Practices.IoC;

namespace LogoFX.Web.Core
{
    public abstract class BootstrapperBase
    {
        private bool _isInitialized;       
        private readonly IIocContainer _iocContainer;       
        private IAssembliesResolver _assembliesResolver;
        private IHttpControllerTypeResolver _typeResolver;
        private IHttpControllerActivator _controllerActivator;
        private object _defaultLifetimeScope;        

        protected BootstrapperBase(IIocContainer iocContainer)
            : this(HttpControllerTypeResolver.IsControllerType)
        {            
            _iocContainer = iocContainer;
        }

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private BootstrapperBase(Predicate<Type> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }            
        }

        /// <summary>
        /// Starts the runtime.
        /// </summary>
        public void Start()
        {
            if (_isInitialized)
            {
                return;
            }
            _isInitialized = true;           
            StartRuntime();
        }        
        
        /// <summary>
        /// Gets the location of executable modules.
        /// </summary>
        public virtual string ModulesPath => string.Empty;

        protected void SetupHttpConfiguration(IHttpConfigurationProxy config)
        {            
            config.MapHttpRoutes();
            config.ReplaceService(_assembliesResolver);
            config.ReplaceService(_typeResolver);
            config.ReplaceService(_controllerActivator);            
        }

        /// <summary>
        /// Gets the current lifetime scope.
        /// </summary>
        /// <value>The current lifetime scope.</value>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        protected virtual object CurrentLifetimeScope => _defaultLifetimeScope ?? (_defaultLifetimeScope = new object());

        private void StartRuntime()
        {            
            var directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var path = Path.Combine(directoryInfo.FullName, ModulesPath);
            var initializationFacade = new BootstrapperInitializationFacade(_iocContainer);  
            initializationFacade.Initialize(path);
            //code smell
            _assembliesResolver = initializationFacade.AssembliesResolver as IAssembliesResolver;
            _typeResolver = new HttpControllerTypeResolver();
            _controllerActivator = new HttpControllerActivator();
            RegisterServices();              
            Configure();
            RegisterControllers(_typeResolver.GetControllerTypes(_assembliesResolver));            
        }

        protected abstract void Configure();

        private void RegisterServices()
        {
            _iocContainer.RegisterInstance(_iocContainer);
            _iocContainer.RegisterInstance(_assembliesResolver);
            _iocContainer.RegisterInstance(_typeResolver);
            _iocContainer.RegisterInstance(_controllerActivator);            
        }

        private void RegisterControllers(IEnumerable<Type> controllerTypes)
        {
            foreach (var controllerType in controllerTypes)
            {
                _iocContainer.RegisterTransient(controllerType, controllerType);
            }            
        }                      
    }    
}