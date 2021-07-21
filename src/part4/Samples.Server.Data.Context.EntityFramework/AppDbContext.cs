using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public new IDbSet<TEntity> Set<TEntity>() 
            where TEntity : class
        {
            if (typeof(TEntity) == typeof(Court) && _courtLevels == null)
            {
                _courtLevels = base.Set<CourtLevel>();
                var courtLevels = _courtLevels.ToList();
            }

            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Court>()
                .HasRequired(c => c.Level)
                .WithMany(l => l.Courts)
                .HasForeignKey(c => c.LevelId);

            modelBuilder.Entity<Court>()
                .ToTable("Courts");

            modelBuilder.Entity<CourtLevel>()
                .ToTable("CourtLevels");
        }

        private DbSet<CourtLevel> _courtLevels;
    }
}