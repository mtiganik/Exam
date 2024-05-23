using Domain;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
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

        private readonly AppDbContext _Context;

        public TodoCategoryService(AppDbContext Context)
        {
            _Context = Context;
        }

        public Task<int> CreateAsync(TodoCategory todoCategory)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoCategory>> GetAllAsync()
        {
            var res = await _Context.TodoCategories.ToListAsync();
            return res;
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
