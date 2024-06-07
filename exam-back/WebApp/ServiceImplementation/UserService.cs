using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Services.DTO.User;
using Services.Interfaces;

namespace WebApp.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserGetter _userGetter;
        public UserService(AppDbContext context, IUserGetter userGetter)
        {
            _context = context;
            _userGetter = userGetter;
        }
        public async Task<IEnumerable<UserUsersDTO>> GetCompanyUsers()
        {
            var currUser = await _userGetter.GetCurrentUserAsync();
            var res = new List<UserUsersDTO>();
            var users = await _context.Users.Where(u => u.CompanyId == currUser.CompanyId).ToListAsync();
            foreach ( var user in users )
            {
                res.Add(new UserUsersDTO()
                {
                    UserName = user.UserName,
                    UserEmail = user.Email
                });
            }
            return res;
        }

        public async Task<IEnumerable<string>> GetYourItems()
        {
            var currUser = await _userGetter.GetCurrentUserAsync();
            var items = await _context.Items.Where(u => u.UserToGiveOutId == currUser.Id).ToListAsync();

            List<string> result = new List<string>();
            foreach ( var item in items )
            {
                result.Add(item.ItemName);
            }
            return result;

        }

        public async Task<int> LogWork(int ActivityMinutes)
        {
            var currUser = await _userGetter.GetCurrentUserAsync();
            currUser.ActivityMinutes = currUser.ActivityMinutes + ActivityMinutes;
            await _context.SaveChangesAsync();
            return currUser.ActivityMinutes;
        }
    }
}
