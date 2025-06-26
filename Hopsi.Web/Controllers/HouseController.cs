using Hospi.Core.Interfaces.Services    ;
using Microsoft.AspNetCore.Mvc;

namespace Hopsi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseBusiessService) 
        {
            _houseService = houseBusiessService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await _houseService.SearchAsync(token);

           return Ok(result);
        }
    }
}
