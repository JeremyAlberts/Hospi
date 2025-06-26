namespace Hopsi.Api.Options
{
    public class JwtOptions
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecretKey { get; set; }
        public int ExpiryMinutes { get; set; }
        public int RefreshTokenExpiryTime { get; set; }
    }
}
