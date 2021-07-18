using JetBrains.Annotations;
using LogoFX.Data.DbContext.EntityFramework;

namespace Samples.Server.Data.Context.EntityFramework
{
    [UsedImplicitly]
    public class TransactionConcreteFactory : TransactionAbstractFactory<AppDbContext>
    {
        private readonly IDbContextFactory _dbContextFactory;

        public TransactionConcreteFactory(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override AppDbContext CreateDbContext()
        {
            return _dbContextFactory.CreateDbContext<AppDbContext>();
        }
    }
}