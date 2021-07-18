using System.Data;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    public abstract class TransactionAbstractFactory<TContext> : ITransactionFactory
        where TContext : class, IDbContext
    {
        protected abstract TContext CreateDbContext();

        IDbTransaction ITransactionFactory.CreateTransaction()
        {
            var context = CreateDbContext();
            var result = context.Connection.BeginTransaction();
            return result;
        }
    }
}
