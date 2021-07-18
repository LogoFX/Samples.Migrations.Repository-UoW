using LogoFX.Data.DbContext.AdoDotNet;

namespace Samples.Server.Data.Context.AdoDotNet
{
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