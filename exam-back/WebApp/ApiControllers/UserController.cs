using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.DTO.User;
using Services.Interfaces;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin, su")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        [HttpPut("LogWork")]
        public async Task<ActionResult<int>> LogWork(int minutes)
        {
            try
            {
                var res = await _userService.LogWork(minutes);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetYourItems")]
        public async Task<ActionResult<List<string>>> GetYourItems()
        {
            try
            {
                var res = await _userService.GetYourItems();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetCompanyUsers")]
        public async Task<ActionResult<UserUsersDTO>> GetCompanyUsers()
        {
            try
            {
                var res = await _userService.GetCompanyUsers();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
