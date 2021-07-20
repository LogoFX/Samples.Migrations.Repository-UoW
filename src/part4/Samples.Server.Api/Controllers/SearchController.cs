using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

// ReSharper disable UnusedParameterInPartialMethod

namespace Samples.Server.Api.Controllers
{
    public partial class SearchController
    {
        private partial Task<IHttpActionResult> PostSearchQueryImplementationAsync(QueryDto body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}