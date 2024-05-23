using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ITodoCategoryService _service;

        public CategoriesController(ITodoCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoCategory>>> GetAll()
        {
            try
            {
                var categories = await _service.GetAllAsync();
                return Ok(categories);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
