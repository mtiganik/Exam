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
    public class TodoPriorityService : ITodoPriorityService
    {
        private readonly AppDbContext _Context;

        public TodoPriorityService(AppDbContext Context)
        {
            _Context = Context;
        }

        public Task<int> CreateAsync(TodoPriority todoPriority)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoPriority>> GetAllAsync()
        {
            var res = await _Context.TodoPriorities.ToListAsync();
            return res;
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
