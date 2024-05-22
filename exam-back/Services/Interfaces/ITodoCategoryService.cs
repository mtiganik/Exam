using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodoCategoryService
    {
        public Task<IEnumerable<TodoCategory>> GetAllAsync();
        public Task<TodoCategory> GetById(Guid Id);
        public Task<int> CreateAsync(TodoCategory todoCategory);
        public Task<int> UpdateAsync(TodoCategory todoCategory);
        public Task<int> DeleteAsync(Guid id);

    }
}
