using Hopsi.Api.DTOs.House;
using Hospi.Core.Entities;
using Hospi.Core.Interfaces.Services;
using Hospi.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hopsi.Api.Controllers
{
    [ApiController]
    [Route("HospiApi/[controller]")]
    public class HouseController : BaseController
    {
        private readonly IHouseService _houseService;
        private readonly UserManager<AppUser> _userManager;

        public HouseController(IHouseService houseBusiessService, UserManager<AppUser> userManager)
        {
            _houseService = houseBusiessService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetHouses(CancellationToken token)
        {
            var result = await _houseService.GetHousesByOwnerId(UserId, token);

            return Ok(result);
        }

        [HttpGet("{houseId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetHouse(Guid houseId, CancellationToken token)
        {
            var result = await _houseService.GetById(houseId, token);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] HouseCreateDTO houseCreateDTO, CancellationToken token)
        {
            var user = await _userManager.FindByIdAsync(UserIdAsString);

            var model = new HouseCreateModel
            {
                StreetName = houseCreateDTO.StreetName,
                HouseNumber = houseCreateDTO.HouseNumber,
                PostalCode = houseCreateDTO.PostalCode,
                City = houseCreateDTO.City,
                ImageUrl = houseCreateDTO.ImageUrl,
                Description = houseCreateDTO.Description,
                Affiliation = houseCreateDTO.Affiliation,
                Owner = user
            };

            await _houseService.Create(model, token);

            return Ok();
        }

        [HttpDelete("{houseId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid houseId, CancellationToken token)
        {
            await _houseService.Delete(UserId, houseId, token);

            return NoContent();
        }
    }
}
