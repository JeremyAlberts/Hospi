using Hopsi.Api.DTOs.Auth;
using Hopsi.Api.Interfaces;
using Hospi.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hopsi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }


        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO, CancellationToken token)
        //{
        //    _logger.LogInformation("Logging in user {@request}", loginDTO);
        //    //var result = await _authenticationService.Login(loginDTO, token);

        //    return Ok();
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO, CancellationToken token)
        {
            _logger.LogInformation("Registering user {@RegisterDTO}", registerDTO);

            var model = new RegisterUserModel {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                Password = registerDTO.Password,
            };

            var res = await _authService.Register(model);

            return Ok(res);
        }
    }
}
