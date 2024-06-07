using Services.DTO;
using Services.DTO.Admin;
using Services.DTO.SuperUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminCompanyDTO> CompanyAdd (AdminCompanyDTO company);
        Task CompanyDelete (Guid Id);
        Task<AdminCompanyDTO> CompanyUpdate (AdminCompanyDTO company);
        Task<IEnumerable<AdminCompanyDTO>> GetAllCompanies();

    }
}
