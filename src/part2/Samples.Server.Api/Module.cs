using System.ComponentModel.Composition;
using AutoMapper;
using JetBrains.Annotations;
using LogoFX.Practices.Composition;
using LogoFX.Practices.IoC;
using Samples.Server.Api.Mappers;

namespace Samples.Server.Api
{
    [UsedImplicitly]
    [Export(typeof(ICompositionModule))]
    internal sealed class Module : ICompositionModule
    {
        public void RegisterModule(IIocContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            container.RegisterInstance(config.CreateMapper());
            container.RegisterSingleton<CourtMapper, CourtMapper>();
        }
    }
}