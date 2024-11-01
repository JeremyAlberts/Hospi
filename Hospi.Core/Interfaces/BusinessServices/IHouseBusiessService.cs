using Hospi.Core.Entities;

namespace Hospi.Core.Interfaces.BusinessServices
{
    public interface IHouseBusiessService
    {
        Task<House> GetById(Guid id, CancellationToken token);
        Task<IReadOnlyCollection<House>> SearchAsync(CancellationToken token);
    }
}
