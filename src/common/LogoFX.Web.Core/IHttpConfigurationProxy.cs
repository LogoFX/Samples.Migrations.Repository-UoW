using System.Web.Http;

namespace LogoFX.Web.Core
{
    public interface IHttpConfigurationProxy
    {        
        IHttpConfigurationProxy MapHttpRoutes();
        IHttpConfigurationProxy ReplaceService<TService>(TService service);
        HttpConfiguration HttpConfiguration { get; }
    }
}
