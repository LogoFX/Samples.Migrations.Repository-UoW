using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.Server.Api.Controllers
{
    public partial class EntitiesController
    {
        /// <summary>Listing Entity types</summary>
        /// <returns>OK</returns>
        private partial Task<IHttpActionResult> GetEntitiesImplementationAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}