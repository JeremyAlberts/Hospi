using System.Security.Claims;

namespace Hopsi.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var userIdStr = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdStr))
                throw new InvalidOperationException("User ID claim not found.");

            if (!Guid.TryParse(userIdStr, out var userId))
                throw new InvalidOperationException("User ID claim is not a valid GUID.");

            return userId;
        }

        public static string GetUserIdAsString(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var userIdStr = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdStr))
                throw new InvalidOperationException("User ID claim not found.");

            return userIdStr;
        }
    }
}
