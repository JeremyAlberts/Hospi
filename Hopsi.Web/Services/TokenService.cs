using Hopsi.Api.Interfaces;
using Hopsi.Api.Options;
using Hospi.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hopsi.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager, ILogger<TokenService> logger)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<string> GenerateAccesToken(AppUser user)
        {
            _logger.LogInformation("Generating access token for user {@user}", user);

            var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(
                _jwtOptions.ValidIssuer,
                _jwtOptions.ValidAudience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
