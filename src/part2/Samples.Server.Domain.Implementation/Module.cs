using System.ComponentModel.Composition;
using LogoFX.Practices.IoC;
using Microsoft.Extensions.DependencyInjection;
using Samples.Server.Domain.Contracts;
using Samples.Server.Domain.Implementation.Services;
using Solid.Practices.Modularity;
using ICompositionModule = LogoFX.Practices.Composition.ICompositionModule;

namespace Samples.Server.Domain.Implementation
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule, ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IIocContainer container)
        {
            container.RegisterSingleton<IValueService, ValueService>();
            container.RegisterSingleton<ICourtsService, CourtsService>();
        }

        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IValueService, ValueService>();
            dependencyRegistrator.AddSingleton<ICourtsService, CourtsService>();
        }
    }
}