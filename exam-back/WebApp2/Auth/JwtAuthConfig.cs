namespace WebApp2.Auth
{
    public class JwtAuthConfig
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int ExpiresInSeconds { get; set; }

    }
}
