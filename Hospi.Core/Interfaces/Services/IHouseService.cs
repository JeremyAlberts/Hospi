using Hospi.Core.Entities;

namespace Hospi.Core.Interfaces.Services
{
    public interface IHouseService
    {
        Task<House> GetById(Guid id, CancellationToken token);
        Task<IReadOnlyCollection<House>> SearchAsync(CancellationToken token);
    }
}
