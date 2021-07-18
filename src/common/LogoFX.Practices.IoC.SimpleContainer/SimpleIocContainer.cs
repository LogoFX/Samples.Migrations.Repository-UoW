using System;
using System.Collections.Generic;

namespace LogoFX.Practices.IoC.SimpleContainer
{
    public class SimpleIocContainer : IIocContainer, IServiceLocator
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterPerRequest(typeof(TService), null, typeof(TImplementation));
        }

        public void RegisterTransient<TService>() where TService : class
        {
            RegisterTransient<TService, TService>();
        }

        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            _container.RegisterPerRequest(serviceType, null, implementationType);
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterSingleton(typeof(TService), null, typeof(TImplementation));
        }

        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _container.RegisterInstance(typeof(TService), null, instance);
        }

        public TService GetInstance<TService>(Type serviceType) where TService : class
        {
            return (TService)_container.GetInstance(serviceType, null);
        }

        public TService GetInstance<TService>() where TService : class
        {
            return GetInstance<TService>(typeof (TService));
        }

        public object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType, null);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        public void BuildUp(object instance)
        {
            _container.BuildUp(instance);            
        }
    }
}