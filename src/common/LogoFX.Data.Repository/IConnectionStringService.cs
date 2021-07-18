namespace LogoFX.Data.Repository
{
    public interface IConnectionStringService
    {
        string GetConnectionString();

        string GetProviderName();
    }
}