using System.Web.Http;

namespace LogoFX.WebApi2.Core
{
    public abstract class ApiControllerBase : ApiController
    {
	    protected string Upn => null;
    }
}