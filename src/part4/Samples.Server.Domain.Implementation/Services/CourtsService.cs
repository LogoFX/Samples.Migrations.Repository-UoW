using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Data.Repository;
using Samples.Server.Domain.Contracts;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Domain.Implementation.Services
{
    [UsedImplicitly]
    internal sealed class CourtsService : ICourtsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourtsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Court[]> ICourtsService.GetCourtsAsync(CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Court>();
            var courts = await Task.Run(() => repository.GetAll().ToArray(), cancellationToken);
            return courts;
        }
    }
}