namespace WebApp.Auth.DTOs
{
    public class RegisterInfo
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
        public Guid CompanyId { get; set; } = default!;

    }
}
