using System;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    public interface IDbContextFactory
    {
        TContext CreateDbContext<TContext>()
            where TContext : class, IDbContext;
    }

    public class DbContextFactory : IDbContextFactory
    {
        public TContext CreateDbContext<TContext>()
            where TContext : class, IDbContext
        {
            return (TContext) Activator.CreateInstance(typeof(TContext));
        }
    }
}
