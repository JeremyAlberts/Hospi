using Hospi.Core.Entities;
using System.Security.Claims;

namespace Hopsi.Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccesToken(AppUser user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        //Task<RefreshTokenDTO> RefreshToken(string accessToken, string refreshToken);
    }
}
