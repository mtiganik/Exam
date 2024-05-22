using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodoService
    {
        public Task<IEnumerable<Todo>> GetAllAsync();
        public Task<Todo> GetById(Guid Id);
        public Task<int> CreateAsync(Todo todo);
        public Task<int> UpdateAsync(Todo todo);
        public Task<int> DeleteAsync(Guid id);
    }
}
