using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Services.DTO.FrontPage;
using Services.Interfaces;

namespace WebApp.ServiceImplementation
{
    public class FrontPageService : IFrontPageService
    {
        private readonly AppDbContext _context;
        public FrontPageService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FrontPageDTO>> GetPublicCompanies()
        {
            var cpies = await _context.Companies.Where(u => u.IsPublic == true).ToListAsync();
            List<FrontPageDTO> res = new List<FrontPageDTO>();
            foreach(var item in cpies)
            {
                res.Add(new FrontPageDTO()
                {
                    CompanyName = item.CompanyName,
                    CompanyId = item.Id,
                });
            }
            return res;
        }
    }
}
