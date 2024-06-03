using Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
using WebApp.Auth;
using WebApp.Auth.DTOs;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AdminController(IAuthService authService, AppDbContext context, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _context = context;
            _userManager = userManager;
        }

        [HttpPut("CreateSU")]
        public async Task<ActionResult> CreateSU([FromBody] RegisterInfo info)
        {
            try
            {
                var res = await _authService.Register(info, "su");
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<AdminUserData>>> GetAllUsers()
        {
            try
            {
                var res = new List<AdminUserData>();
                var users = await _context.Users.ToListAsync();
                foreach(var user in users)
                {
                    res.Add(new AdminUserData()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        Email = user.Email
                    });
                }
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(AdminUserData data)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(data.Email);
                if(user == null)
                {
                    return BadRequest("User not found");
                }
                var res = _userManager.DeleteAsync(user);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
