using WebApp.Auth.DTOs;

namespace WebApp.Auth
{
    public interface IAuthService
    {
        Task<JWTResponse> Register(RegisterInfo model, string role);
        Task<JWTResponse> Login(LoginInfo model);
        Task<JWTResponse> RefreshToken(TokenRefreshInfo model);
        Task<int> Logout(string userIdStr, string refreshToken);

    }
}
