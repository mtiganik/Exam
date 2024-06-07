namespace WebApp.Auth.DTOs
{
    public class JWTResponse
    {
        public string Jwt { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Guid CompanyId { get; set; } = default!;
        public string[] Role { get; set;} = default!;

    }
}
