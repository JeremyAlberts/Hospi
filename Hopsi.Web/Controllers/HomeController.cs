using Hopsi.Web.Models;
using Hopsi.Web.Models.House;
using Hospi.Core.Interfaces.BusinessServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hopsi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHouseBusiessService _houseBusiessService;

        public HomeController(IHouseBusiessService houseBusiessService, ILogger<HomeController> logger)
        {
            _houseBusiessService = houseBusiessService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await _houseBusiessService.SearchAsync(CancellationToken.None);

            var viewModel = new HousesViewModel
            {
                Houses = houses.Select(house => new HouseViewModel
                {
                    Id = house.Id,
                    Name = house.Name,
                    Affiliation = house.Affiliation,
                    City = house.City,
                    HouseNumber = house.HouseNumber,
                    PostalCode = house.PostalCode,
                    StreetName = house.StreetName,
                    ImageUrl = house.ImageUrl,
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InfoLIst()
        {
            return PartialView("List", new ListModel
            {
                Name = "Info",
                Values = new List<string> { "Info1", "Info2", "Info3" }
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
