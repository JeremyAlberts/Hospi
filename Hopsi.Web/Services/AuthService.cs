using Hopsi.Api.Interfaces;
using Hospi.Core.Entities;
using Hospi.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Hopsi.Api.Core
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(ILogger<AuthService> logger, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Register(RegisterUserModel registerUserModel)
        {
            try
            {
                _logger.LogInformation("Registering user {@registerUserModel}", registerUserModel);

                var user = new AppUser
                {
                    FirstName = registerUserModel.FirstName,
                    LastName = registerUserModel.LastName,
                    Email = registerUserModel.Email,
                    UserName = $"{registerUserModel.FirstName}{registerUserModel.LastName}"
                };

                var result = await _userManager.CreateAsync(user, registerUserModel.Password);

                if (!result.Succeeded) throw new Exception(result.Errors.First().Description);

                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                    throw new Exception(roleResult.Errors.First().Description);

                var token = await _tokenService.GenerateAccesToken(user);

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Registering user went wrong {@registerUserModel}", registerUserModel);
                return "Failed";
            }
        }
    }
}
