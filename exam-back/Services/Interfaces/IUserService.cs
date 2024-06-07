using Services.DTO.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<int> LogWork(int ActivityMinutes);
        Task<IEnumerable<string>> GetYourItems();
        Task<IEnumerable<UserUsersDTO>> GetCompanyUsers();
    }
}
