using Services.DTO;
using Services.DTO.Admin;
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
        Task<AdminCompanyDTO> CompanyDelete (AdminCompanyDTO company);
        Task<AdminCompanyDTO> CompanyUpdate (AdminCompanyDTO company);
        Task<IEnumerable<AdminCompanyDTO>> GetAllCategories();
    }
}
