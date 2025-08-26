using Hospi.Core.Entities;

namespace Hospi.Core.Interfaces
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<IReadOnlyCollection<House>> GetHousesByOwnerId(Guid owenerId, CancellationToken token);
        Task<IReadOnlyCollection<House>> DeletetHousesByOwnerId(Guid owenerId, Guid id, CancellationToken token);
        Task<House> GetByIdAndOwnerId(Guid ownerId, Guid id, CancellationToken token);
    }
}
