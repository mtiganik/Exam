using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodoPriorityService
    {
        public Task<IEnumerable<TodoPriority>> GetAllAsync();
        public Task<TodoPriority> GetById(Guid Id);
        public Task<int> CreateAsync(TodoPriority todoPriority);
        public Task<int> UpdateAsync(TodoPriority todoPriority);
        public Task<int> DeleteAsync(Guid id);

    }
}
