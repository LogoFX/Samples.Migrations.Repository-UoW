using LogoFX.Web.Core;

namespace LogoFX.WebApi2.Core
{
	public interface IHttpConfigurationProvider
	{
		IHttpConfigurationProxy GetConfiguration();
	}
}