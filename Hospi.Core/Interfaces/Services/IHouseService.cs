using Hospi.Core.Entities;
using Hospi.Core.Models.House;

namespace Hospi.Core.Interfaces.Services
{
    public interface IHouseService
    {
        Task Create(HouseCreateModel model, CancellationToken token);
        Task Delete(Guid ownerId, Guid houseId, CancellationToken token);
        Task<House> GetById(Guid houseId, CancellationToken token);
        Task<IReadOnlyCollection<House>> GetHousesByOwnerId(Guid ownerId, CancellationToken token);
    }
}
