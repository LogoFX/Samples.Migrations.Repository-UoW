using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Samples.Server.Domain.Contracts;
using Samples.Server.Domain.Entities;

namespace Samples.Server.GraphQL.Facade
{
	public sealed class Query
	{
        public async Task<IEnumerable<Court>> GetCourts([Service] ICourtsService courtsService)
        {
            return await courtsService.GetCourtsAsync();
        }

        public async Task<IEnumerable<CourtLevel>> GetCourtLevels([Service] ICourtLevelsService courtLevelsService)
        {
            return await courtLevelsService.GetCourtLevelsAsync();
        }
    }
}