using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MigrationProject;
using Services.DTO.Admin;
using Services.Interfaces;
using WebApp.Auth;
using WebApp.Auth.DTOs;

namespace WebApp.ServiceImplementation
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public AdminService(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        public async Task<AdminCompanyDTO> CompanyAdd(AdminCompanyDTO company)
        {
            Guid guid = company.Id ?? Guid.NewGuid();
            company.Id = guid;
            Company newCompany = new Company()
            {
                CompanyName = company.CompanyName,
                ActivityMinutes = company.ActivityMinutes,
                Id = guid,
                Sort1 = company.Sort1,
                Sort2 = company.Sort2,
                SuEmail = company.SuEmail,
                SuName = company.SuName,
                SuPw = company.SuPw,
                IsPublic = company.IsPublic,
                Tag = company.Tag,
            };
            RegisterInfo register = new RegisterInfo()
            {
                CompanyId = guid,
                UserName = company.SuName,
                Email = company.SuEmail,
                Password = company.SuPw

            };
            await _context.Companies.AddAsync(newCompany);
            await _authService.Register(register, "su");
            await _context.SaveChangesAsync();
            return company;
        }


        public async Task CompanyDelete(Guid Id)
        {

            var company = await _context.Companies.Where(u => u.Id == Id).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new Exception($"Company with id {Id} not found");
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<AdminCompanyDTO> CompanyUpdate(AdminCompanyDTO companyDto)
        {
            var commpany = await _context.Companies.Where(u => u.Id == companyDto.Id).FirstOrDefaultAsync();
            if (commpany == null)
            {
                throw new Exception($"Company with id {companyDto.Id} not found");
            }
            commpany.SuEmail = companyDto.SuEmail;
            commpany.SuName = companyDto.SuName;
            commpany.SuPw = companyDto.SuPw;
            commpany.CompanyName = companyDto.CompanyName;
            commpany.IsPublic = companyDto.IsPublic;
            commpany.ActivityMinutes = companyDto.ActivityMinutes;
            commpany.Sort1 = companyDto.Sort1;
            commpany.Sort2 = companyDto.Sort2;
            commpany.Tag = companyDto.Tag;
            await _context.SaveChangesAsync();
            return companyDto;
        }

        public async Task<IEnumerable<AdminCompanyDTO>> GetAllCompanies()
        {
            var cpnies = await _context.Companies.ToListAsync();
            var res = new List<AdminCompanyDTO>();
            foreach (var c in cpnies)
            {
                AdminCompanyDTO cDto = new AdminCompanyDTO()
                {
                    SuEmail = c.SuEmail,
                    SuName = c.SuName,
                    SuPw = c.SuPw,
                    CompanyName = c.CompanyName,
                    IsPublic = c.IsPublic,
                    ActivityMinutes = c.ActivityMinutes,
                    Sort1 = c.Sort1,
                    Sort2 = c.Sort2,
                    Tag = c.Tag
                };
                res.Add(cDto);
            }
            return res;
        }
    }
}
