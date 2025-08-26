using Hospi.Core.Entities;
using Hospi.Core.Exceptions;
using Hospi.Core.Interfaces;
using Hospi.Core.Interfaces.Services;
using Hospi.Core.Models.House;

namespace Hospi.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task Create(HouseCreateModel model, CancellationToken token)
        {
            var house = new House
            {
                StreetName = model.StreetName,
                HouseNumber = model.HouseNumber,
                PostalCode = model.PostalCode,
                City = model.City,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Affiliation = model.Affiliation,
                Owner = model.Owner,
            };

            await _houseRepository.AddAsync(house, token);
        }

        public async Task Delete(Guid ownerId, Guid houseId, CancellationToken token)
        {
            var house = await _houseRepository.GetByIdAndOwnerId(ownerId, houseId, token);

            if (house == null)
                throw new NotFoundException($"House with ID '{houseId}' not found for owner '{ownerId}'.");

            await _houseRepository.DeleteAsync(house, token);
        }

        public async Task<House> GetById(Guid houseId, CancellationToken token)
        {
            var house = await _houseRepository.GetByIdAsync(houseId, token);

            if(house == null)
                throw new NotFoundException($"House with id {houseId} not found");

            return house;
        }

        public async Task<IReadOnlyCollection<House>> GetHousesByOwnerId(Guid ownerId, CancellationToken token)
        {
            var houses = await _houseRepository.GetHousesByOwnerId(ownerId, token);

            return houses;
        }
    }
}
