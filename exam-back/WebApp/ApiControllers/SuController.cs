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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, su")]

    public class SuController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public SuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Guid>> CreateCategory(CategoryDTO dto)
        {
            try
            {
                var res = await _categoryService.CreateCategory(dto);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(CategoryDTO dto)
        {
            try
            {
                var res = await _categoryService.UpdateCategory(dto);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
