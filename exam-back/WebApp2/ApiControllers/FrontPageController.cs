using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace WebApp2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontPageController : ControllerBase
    {
        private readonly IFrontPageService _frontpageService;
        public FrontPageController(IFrontPageService frontpageservice)
        {
            _frontpageService = frontpageservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrontPageSubjectDTO>>> GetFrontPageSubjects()
        {
            try
            {
                var res = await _frontpageService.GetFrontPageSubjects();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
