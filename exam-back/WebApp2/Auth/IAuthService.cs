using WebApp2.Auth.DTOs;

namespace WebApp2.Auth
{
    public interface IAuthService
    {
        Task<JWTResponse> Register(RegisterInfo model);
        Task<JWTResponse> Login(LoginInfo model);
        Task<JWTResponse> RefreshToken(TokenRefreshInfo model);
        Task<int> Logout(string userIdStr, string refreshToken);

    }
}
