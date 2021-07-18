using System.Web.Http;
using LogoFX.Practices.IoC.SimpleContainer;

namespace Samples.Server.Facade
{
    /// <summary>
    /// The Web Application starting point.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The method is called at the Web Application start by the system.
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
           new AppBootstrapper(new SimpleIocContainer()).Start();
        }
    }
}
