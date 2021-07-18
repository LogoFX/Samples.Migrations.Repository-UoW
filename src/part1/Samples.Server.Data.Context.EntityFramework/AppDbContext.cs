using System.Data.Entity;
using JetBrains.Annotations;
using LogoFX.Data.DbContext.EntityFramework;
using LogoFX.Data.Repository;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Data.Context.EntityFramework
{
    [UsedImplicitly]
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(IConnectionStringService connectionStringService)
            : base(connectionStringService.GetConnectionString())
        {
            Database.SetInitializer<AppDbContext>(null);

        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Court>().ToTable("Courts");
        }
    }
}