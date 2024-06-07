using Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Services.DTO.Admin;
using Services.Interfaces;
using WebApp.Auth;
using WebApp.Auth.DTOs;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        [HttpPut("AddCompany")]
        public async Task<ActionResult<AdminCompanyDTO>> AddCompany([FromBody] AdminCompanyDTO company)
        {
            try
            {
                var res = await _adminService.CompanyAdd(company);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult<List<AdminCompanyDTO>>> GetAllCompanies()
        {
            try
            {
                var res = await _adminService.GetAllCompanies();
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("CompanyDelete")]
        public async Task<ActionResult> CompanyDelete(Guid Id)
        {
            try
            {
                await _adminService.CompanyDelete(Id);
                return Ok("user deleted");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CompanyUpdate")]
        public async Task<ActionResult<AdminCompanyDTO>> CompanyUpdate(AdminCompanyDTO company)
        {
            try
            {
                var res = await _adminService.CompanyUpdate(company);
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
