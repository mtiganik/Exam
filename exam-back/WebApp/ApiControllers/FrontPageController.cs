using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontPageController : ControllerBase
    {

        [HttpGet("frontPageGet")]
        public ActionResult<List<string>> GetFrontPageData()
        {
            var res = new List<string>()
            {
                "hello",
                "World",
                "three",
                "Times"
            };
            return Ok(res);
        }
    }
}
