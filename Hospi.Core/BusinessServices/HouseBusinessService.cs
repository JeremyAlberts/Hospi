using Hospi.Core.Entities;
using Hospi.Core.Interfaces;
using Hospi.Core.Interfaces.BusinessServices;

namespace Hospi.Core.BusinessServices
{
    public class HouseBusinessService : IHouseBusiessService
    {
        private readonly IRepository<House> _houseRepository;

        public HouseBusinessService(IRepository<House> houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<House> GetById(Guid id, CancellationToken token)
        {
            var house = await _houseRepository.GetByIdAsync(id, token);

            return house;
        }

        public async Task<IReadOnlyCollection<House>> SearchAsync(CancellationToken token)
        {
            var houses = await _houseRepository.GetAsync(token);

            return houses;
        }
    }
}
