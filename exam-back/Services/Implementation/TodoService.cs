using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TodoService : ITodoService
    {
        public Task<TodoDTO> CreateTodo(TodoDTO TodoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TodoDTO> DeleteTodo(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TodoDTO> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoDTO> Update(TodoDTO TodoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
