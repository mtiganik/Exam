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
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _Context;

        public TodoService(AppDbContext Context)
        {
            _Context = Context;
        }
        public Task<int> CreateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var res = await _Context.Todos.ToListAsync();
            return res;
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
