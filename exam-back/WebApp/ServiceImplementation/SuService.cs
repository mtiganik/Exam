using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MigrationProject;
using Services.DTO.SuperUser;
using Services.Interfaces;
using System.Collections;
using WebApp.Auth;

namespace WebApp.ServiceImplementation
{
    public class SuService : ISuService
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        //private readonly JwtAuthConfig _jwtAuthConfig;
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly AuthService _authService;
        private readonly IUserGetter _userGetter;
        public SuService(IUserGetter userGetter, AppDbContext context)
        {
            _userGetter = userGetter;
            _context = context;
        }
        public async Task<IEnumerable<ItemDTO>> AddItems(List<string> inputArr)
        {
            var user = await _userGetter.GetCurrentUserAsync();
            List<ItemDTO> res = new List<ItemDTO>();
            Guid companyId = user.CompanyId;
            foreach (string el in inputArr)
            {
                Item item = new Item()
                {
                    Id = Guid.NewGuid(),
                    ItemName = el,
                    UserToGiveOutId = null,
                    CompanyId = companyId,
                    IsGivenOut = false,
                };
                await _context.Items.AddAsync(item);
                res.Add(new ItemDTO()
                {
                    Id = item.Id,
                    Name = item.ItemName,
                    IsGivenOut = false,
                    UserToGiveOutId = null,
                });
            }
            await _context.SaveChangesAsync();
            return res;
        }


        public async Task<ItemDTO> DeleteItem(ItemDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemDTO> EditItem(ItemDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<ShuffleResultDTO> ExecuteShuffle()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
        public async Task<UserDTO> CreateUser(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> DeteleUser(Guid guid)
        {
            throw new NotImplementedException();
        }

    }
}
