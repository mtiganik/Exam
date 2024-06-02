using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;

namespace WebApp2.Helpers
{
    public class UserGetter : IUserGetter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public UserGetter(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor.HttpContext!.User;
            if (user.Identity!.IsAuthenticated)
            {
                return await _userManager.GetUserAsync(user);
            }
            return null;
        }
    }
}
