using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.Server.Api.Controllers
{
    /// <inheritdoc />
    [SuppressMessage("ReSharper", "UnusedParameterInPartialMethod")]
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