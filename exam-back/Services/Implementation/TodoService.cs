using Domain;
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
        public Task<int> CreateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
