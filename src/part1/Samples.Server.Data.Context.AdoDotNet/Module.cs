using System.ComponentModel.Composition;
using LogoFX.Data.DbContext.AdoDotNet;
using LogoFX.Data.Repository;
using LogoFX.Data.Repository.AdoDotNet;
using LogoFX.Practices.Composition;
using LogoFX.Practices.IoC;

namespace Samples.Server.Data.Context.AdoDotNet
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule
    {
        public void RegisterModule(IIocContainer container)
        {
            container.RegisterSingleton<IUnitOfWork, UnitOfWork>();
            container.RegisterSingleton<IDbContext, AppDbContext>();
            container.RegisterTransient<ITransactionFactory, TransactionConcreteFactory>();
            container.RegisterTransient<IDbContextFactory, DbContextFactory>();
        }
    }
}