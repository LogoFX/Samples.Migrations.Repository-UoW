using System.ComponentModel.Composition;
using LogoFX.Practices.Composition;
using LogoFX.Practices.IoC;
using Samples.Server.Domain.Contracts;
using Samples.Server.Domain.Implementation.Services;

namespace Samples.Server.Domain.Implementation
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule
    {
        public void RegisterModule(IIocContainer container)
        {
            container.RegisterSingleton<IValueService, ValueService>();
            container.RegisterSingleton<ICourtsService, CourtsService>();
        }
    }
}