using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.Server.Api.Controllers
{
    public partial class InterestsController
    {
        /// <summary>Listiting Interest types</summary>
        /// <returns>OK</returns>
        private partial Task<IHttpActionResult> GetInterestsImplementationAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}