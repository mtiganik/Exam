using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin, su")]

    public class UserController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryService _categoryService;

        public UserController(ITodoService todoService, ICategoryService categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }

        [HttpGet("AllCategories")]
        public async Task<ActionResult<List<CategoryDTO>>> AllCategories()
        {
            try
            {
                var res = await _categoryService.GetAllCategories();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(Guid id)
        {
            try
            {
                var res = await _categoryService.GetCategoryById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("allTodos")]
        public async Task<ActionResult<List<TodoDTO>>> getAlltodos()
        {
            try
            {
                var res = await _todoService.GetAll();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTodoById")]
        public async Task<ActionResult<TodoDTO>> GetById(Guid id)
        {
            try
            {
                var res = await _todoService.GetById(id);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateTodo")]
        public async Task<ActionResult<TodoDTO>> UpdateTodo(TodoDTO dto)
        {
            try
            {
                var res = await _todoService.Update(dto);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateTodo")]
        public async Task<ActionResult<TodoDTO>> CreateTodo(TodoDTO dto)
        {
            try
            {
                var res = await _todoService.CreateTodo(dto);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteTodo")]
        public async Task<ActionResult<TodoDTO>> DeleteTodo(Guid id)
        {
            try
            {
                var res =await _todoService.DeleteTodo(id);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
