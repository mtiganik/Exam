using Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Auth.DTOs;
using WebApp.Auth;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;
        public AccountController(UserManager<AppUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }


        [HttpPost]
        public async Task<ActionResult<JWTResponse>> Register([FromBody] RegisterInfo registrationData)
        {
            try
            {
                var result = await _authService.Register(registrationData, "user");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<JWTResponse>> Login([FromBody] LoginInfo loginInfo)
        {
            try
            {
                var res = await _authService.Login(loginInfo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<JWTResponse>> RefreshTokenData([FromBody] TokenRefreshInfo tokenRefreshInfo)
        {
            try
            {
                var res = await _authService.RefreshToken(tokenRefreshInfo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> Logout([FromBody] LogoutInfo logout)
        {
            // delete the refresh token - so user is kicked out after jwt expiration
            // We do not invalidate the jwt on serverside - that would require pipeline modification and checking against db on every request
            // so client can actually continue to use the jwt until it expires (keep the jwt expiration time short ~1 min)
            var userIdStr = _userManager.GetUserId(User);
            if (userIdStr == null)
            {
                return BadRequest("Invalid refresh token");
            }
            try
            {
                var res = await _authService.Logout(userIdStr, logout.RefreshToken);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}