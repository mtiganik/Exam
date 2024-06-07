using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.FrontPage;
using Services.Interfaces;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontPageController : ControllerBase
    {
        private readonly IFrontPageService _frontPageService;
        public FrontPageController(IFrontPageService frontPageService)
        {
            _frontPageService = frontPageService;
        }

        [HttpGet("frontPageGet")]
        public async Task<ActionResult<List<FrontPageDTO>>> GetFrontPageData()
        {
            try
            {
                var res = await _frontPageService.GetPublicCompanies();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
