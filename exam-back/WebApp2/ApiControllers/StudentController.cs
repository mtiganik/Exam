using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace WebApp2.ApiControllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getStudentSubs")]
        public async Task<ActionResult<IEnumerable<FrontPageSubjectDTO>>> GetStudentSubs()
        {
            try
            {
                var res = await _studentService.GetStudentSubjects();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("HW")]
        public async Task<ActionResult<IEnumerable<StudentHwDTO>>> GetStudentHWs()
        {
            try
            {
                var res = await _studentService.GetStudentHws();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("studentsForSub")]
        public async Task<ActionResult<IEnumerable<string>>> getSubStudents(Guid subjectId)
        {
            try
            {
                var res = await _studentService.GetUsersForSubject(subjectId);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
