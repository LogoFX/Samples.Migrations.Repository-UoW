using System.Data.Entity.Infrastructure;

namespace LogoFX.Data.DbContext.EntityFramework
{
    public interface IDbContextConfiguration
    {
        DbContextConfiguration ContextConfiguration { get; }
    }    
}
