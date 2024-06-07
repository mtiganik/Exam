using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MigrationProject;
using Services.DTO.SuperUser;
using Services.Interfaces;
using System.Collections;
using WebApp.Auth;
using WebApp.Auth.DTOs;

namespace WebApp.ServiceImplementation
{
    public class SuService : ISuService
    {
        private readonly AppDbContext _context;
        private readonly IUserGetter _userGetter;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;

        public SuService(IUserGetter userGetter, AppDbContext context, UserManager<AppUser> userManager, IAuthService authService)
        {
            _userGetter = userGetter;
            _context = context;
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<IEnumerable<ShuffleResultDTO>> ExecuteShuffle()
        {
            var curruser = await _userGetter.GetCurrentUserAsync();
            var company = await _context.Companies.Where(u => u.Id == curruser.Id).FirstOrDefaultAsync();

            var companyUsersToPlay = await _context.Users
                .Where(u => u.CompanyId == company.Id && u.ActivityMinutes >= company.ActivityMinutes).ToListAsync();

            var items = await _context.Items
                .Where(u => u.IsGivenOut == false && u.CompanyId == company.Id).ToListAsync();
            var usersCnt = companyUsersToPlay.Count();
            var itemsCnt = items.Count();
            if(usersCnt < 2)
            {
                throw new Exception("Atleast 2 users has to be in company to play");
            }
            if(itemsCnt == 0)
            {
                throw new Exception("No gifts to give out");
            }
            var iteration = usersCnt < itemsCnt ? usersCnt : itemsCnt;
            List<ShuffleResultDTO> res = new List<ShuffleResultDTO>();
            for(int i = 0; i < iteration; i++)
            {
                items[i].IsGivenOut = true;
                items[i].UserToGiveOutId = companyUsersToPlay[i].Id;
                res.Add(new ShuffleResultDTO()
                {
                    GiftReceived = items[i].ItemName,
                    UserName = companyUsersToPlay[i].UserName
                });
            }
            await _context.SaveChangesAsync();
            return res;
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


        public async Task DeleteItem(Guid id)
        {
            var item = _context.Items.Where(u => u.Id == id).FirstOrDefault();
            var user = await _userGetter.GetCurrentUserAsync();

            if (item == null || item.CompanyId != user.CompanyId) 
            {
                throw new Exception($"Could not find item with Id {id}");
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemDTO> EditItem(ItemDTO dtoItem)
        {
            var item = _context.Items.Where(u => u.Id == dtoItem.Id).FirstOrDefault();
            var user = await _userGetter.GetCurrentUserAsync();

            if (item == null || item.CompanyId != user.CompanyId)
            {
                throw new Exception($"Could not find item with Id {dtoItem.Id}");
            }
            item.ItemName = dtoItem.Name;
            item.UserToGiveOutId = dtoItem.UserToGiveOutId;
            item.IsGivenOut = (bool)(dtoItem.IsGivenOut == null ? item.IsGivenOut : dtoItem.IsGivenOut);
            await _context.SaveChangesAsync();
            return dtoItem;
        }

        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var items = await _context.Items.Where(u => u.CompanyId == user.CompanyId).ToListAsync();
            List<ItemDTO> res = new List<ItemDTO>();
            foreach( var item in items )
            {
                res.Add(new ItemDTO() { 
                    Id = item.Id, 
                    IsGivenOut = item.IsGivenOut, 
                    Name = item.ItemName,
                    UserToGiveOutId = item.UserToGiveOutId,
                });
            }
            return res;

        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var users = await _context.Users.Where(u => u.CompanyId == user.CompanyId).ToListAsync();
            var res = new List<UserDTO>();
            foreach(var u in users)
            {
                res.Add(new UserDTO()
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    Id = u.Id,
                });
            }
            return res;

        }

        public async Task<UserDTO> UpdateUser(UserDTO userDto)
        {
            var user = _context.Users.Where(u => u.Id == userDto.Id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.UserName = userDto.UserName;
            user.Email = userDto.Email;

            if (!string.IsNullOrWhiteSpace(userDto.UserPassword))
            {
                // Remove the existing password
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (!removePasswordResult.Succeeded)
                {
                    throw new Exception("Failed to remove old password");
                }

                // Add the new password
                var addPasswordResult = await _userManager.AddPasswordAsync(user, userDto.UserPassword);
                if (!addPasswordResult.Succeeded)
                {
                    throw new Exception("Failed to add new password");
                }
                _context.Users.Update(user);
                await _context.SaveChangesAsync();


            }
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };

        }
        public async Task<UserDTO> CreateUser(UserCreateDTO userDto)
        {
            var currUser = await _userGetter.GetCurrentUserAsync();
            RegisterInfo ri = new RegisterInfo()
            {
                CompanyId = currUser.CompanyId,
                Email = userDto.Email,
                UserName = userDto.UserName,
                Password = userDto.UserPassword
            };
            var res = await _authService.Register(ri, "user");
            return new UserDTO()
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
            };
        }

        public async Task DeteleUser(Guid guid)
        {
            // Start a new transaction
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Retrieve the user with related entities
                    var user = await _context.Users
                        .Include(u => u.RefreshTokens)
                        .Include(u => u.Items)
                        .FirstOrDefaultAsync(u => u.Id == guid);

                    if (user == null)
                    {
                        throw new Exception("User not found");
                    }

                    // Remove related AppRefreshTokens
                    _context.RefreshTokens.RemoveRange(user.RefreshTokens!);

                    // Remove related Items
                    _context.Items.RemoveRange(user.Items!);

                    // Remove the user
                    _context.Users.Remove(user);

                    // Save changes
                    await _context.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    await transaction.RollbackAsync();
                    throw new Exception("An error occurred while deleting the user", ex);
                }
            }
        }
    }

}

