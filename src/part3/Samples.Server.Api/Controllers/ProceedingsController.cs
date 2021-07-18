using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.Server.Api.Controllers
{
    public partial class ProceedingsController
    {
        /// <summary>Listing Proceeding types</summary>
        /// <returns>OK</returns>
        private partial Task<IHttpActionResult> GetProceedingsImplementationAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}