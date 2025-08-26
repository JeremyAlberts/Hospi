using Hospi.Core.Entities;
using Hospi.Core.Exceptions;
using Hospi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hopsi.Infrastructure.Repositories
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(HospiDbContext db) : base(db) {}

        public Task<IReadOnlyCollection<House>> DeletetHousesByOwnerId(Guid owenerId, Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<House> GetByIdAndOwnerId(Guid ownerId, Guid id, CancellationToken token)
        {
            var house = await _dbSet.FirstOrDefaultAsync(house =>  house.OwnerId == ownerId && house.Id == id, token);

            return house;
        }

        public async Task<IReadOnlyCollection<House>> GetHousesByOwnerId(Guid owenerId, CancellationToken token)
        {
            var houses = await _dbSet.Where(house => house.OwnerId == owenerId).ToListAsync(token);

            return houses;
        }
    }
}
