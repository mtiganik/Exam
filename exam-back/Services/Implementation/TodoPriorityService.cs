using Domain;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TodoPriorityService : ITodoPriorityService
    {
        public Task<int> CreateAsync(TodoPriority todoPriority)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoPriority>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoPriority> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TodoPriority todoPriority)
        {
            throw new NotImplementedException();
        }
    }
}
