using System.Threading;
using System.Threading.Tasks;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Domain.Contracts
{
    public interface ICourtLevelsService
    {
        Task<CourtLevel[]> GetCourtLevelsAsync(CancellationToken cancellationToken = default);
    }
}