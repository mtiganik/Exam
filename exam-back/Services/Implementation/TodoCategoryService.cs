using Domain;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TodoCategoryService : ITodoCategoryService
    {
        public Task<int> CreateAsync(TodoCategory todoCategory)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoCategory> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TodoCategory todoCategory)
        {
            throw new NotImplementedException();
        }
    }
}
