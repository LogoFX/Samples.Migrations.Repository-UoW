using System.ComponentModel.Composition;
using LogoFX.Data.DbContext.AdoDotNet;
using LogoFX.Data.Repository;
using LogoFX.Data.Repository.AdoDotNet;
using LogoFX.Practices.IoC;
using ICompositionModule = LogoFX.Practices.Composition.ICompositionModule;
#if ADONET
using Solid.Practices.Modularity;
using Microsoft.Extensions.DependencyInjection;
#endif

namespace Samples.Server.Data.Context.AdoDotNet
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule
#if ADONET
        , ICompositionModule<IServiceCollection>
#endif
    {
        public void RegisterModule(IIocContainer container)
        {
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            container.RegisterSingleton<IDbContext, AppDbContext>();
            container.RegisterTransient<ITransactionFactory, TransactionConcreteFactory>();
            container.RegisterTransient<IDbContextFactory, DbContextFactory>();
        }

#if ADONET
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IUnitOfWork, UnitOfWork>();
            dependencyRegistrator.AddSingleton<IDbContext, AppDbContext>();
            dependencyRegistrator.AddSingleton<ITransactionFactory, TransactionConcreteFactory>();
            dependencyRegistrator.AddSingleton<IDbContextFactory, DbContextFactory>();
        }
#endif
    }
}