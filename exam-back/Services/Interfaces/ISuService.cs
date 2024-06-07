using Services.DTO.SuperUser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISuService
    {
        Task<IEnumerable<ItemDTO>> AddItems (List<string> items);
        Task<IEnumerable<ItemDTO>> GetItems();
        Task<ItemDTO> EditItem (ItemDTO item);
        Task<ItemDTO> DeleteItem (ItemDTO item);
        Task<ShuffleResultDTO> ExecuteShuffle();

        Task<UserDTO> CreateUser(UserCreateDTO user);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<IEnumerable> GetAllUsers();
        Task<UserDTO> DeteleUser(Guid guid);
    }
}
