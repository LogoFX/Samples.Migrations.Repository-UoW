using System.Web.Http;
using LogoFX.Data.Repository;
using LogoFX.Practices.IoC;
using LogoFX.WebApi2.Core;

namespace Samples.Server.Facade
{
	public class AppBootstrapper : IisBootstrapper
    {
	    /// <inheritdoc />
	    public AppBootstrapper(IIocContainer iocContainer)
            : base(iocContainer)
        {
			iocContainer.RegisterSingleton<IConnectionStringService, ConnectionStringService>();
        }

	    /// <inheritdoc />
        public override string ModulesPath =>
#if DEBUG && ADONET
			"..\\bin\\AdoNet";
#elif DEBUG && EF
            "..\\bin\\DebugEF";
#else
            "..\\bin\\Release";
#endif

		protected override void Configure()
	    {
		    base.Configure();
			GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilterAttribute());
	    }
    }
}