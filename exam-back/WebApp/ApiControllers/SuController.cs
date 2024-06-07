using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.DTO.SuperUser;
using Services.Interfaces;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, su")]

    public class SuController : ControllerBase
    {
        private readonly ISuService _suService;
        public SuController(ISuService suService)
        {
            _suService = suService;
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDTO>> CreateUser(UserCreateDTO user)
        {
            try
            {
                var res = await _suService.CreateUser(user);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UserDTO>> UpdateCategory(UserDTO user)
        {
            try
            {
                var res = await _suService.UpdateUser(user);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<UserDTO>> GetAllUsers()
        {
            try
            {
                var res = await _suService.GetAllUsers();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeteleUser")]
        public async Task<ActionResult> DeteleUser(Guid guid)
        {
            try
            {
                await _suService.DeteleUser(guid);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddItems")]
        public async Task<ActionResult<ItemDTO>> AddItems(List<string> items)
        {
            try
            {
                var res = await _suService.AddItems(items);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPut("EditItem")]
        public async Task<ActionResult<ItemDTO>> EditItem(ItemDTO item)
        {
            try
            {
                var res = await _suService.EditItem(item);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("GetItems")]
        public async Task<ActionResult<UserDTO>> GetItems()
        {
            try
            {
                var res = await _suService.GetItems();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteItem")]
        public async Task<ActionResult> DeleteItem(Guid Id)
        {
            try
            {
                await _suService.DeleteItem(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ExecuteSuffle")]
        public async Task<ActionResult<ShuffleResultDTO>> ExecuteShuffle()
        {
            try
            {
                var res = await _suService.ExecuteShuffle();
                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
