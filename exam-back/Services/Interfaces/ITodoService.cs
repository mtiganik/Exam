using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoDTO>> GetAll();
        Task<TodoDTO> GetById(Guid Id);
        Task<TodoDTO> Update(TodoDTO TodoDTO);
        Task<TodoDTO> CreateTodo(TodoDTO TodoDTO);
        Task<TodoDTO> DeleteTodo(Guid Id);
    }
}
