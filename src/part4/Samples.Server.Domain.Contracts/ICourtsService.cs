using System.Threading;
using System.Threading.Tasks;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Domain.Contracts
{
    public interface ICourtsService
    {
        Task<Court[]> GetCourtsAsync(CancellationToken cancellationToken = default);
    }
}