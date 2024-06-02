using Domain;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
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
        private readonly AppDbContext _context;
        private readonly IUserGetter _userGetter;
        public TodoService(IUserGetter userGetter, AppDbContext context)
        {
            _context = context;
            _userGetter = userGetter;

        }
        public async Task<TodoDTO> CreateTodo(TodoDTO TodoDTO)
        {
            var user = await _userGetter.GetCurrentUserAsync();
            Guid id = (Guid)(TodoDTO.Id == null ? new Guid() : TodoDTO.Id);
            var todo = new Todo()
            {
                Id = id,
                TaskName = TodoDTO.TaskName,
                TaskSort = TodoDTO.TaskSort,
                AppUserId = user.Id,
            };
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            TodoDTO.Id = id;
            return TodoDTO;
        }

        public async Task<TodoDTO> DeleteTodo(Guid Id)
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var todo = await _context.Todos.Where(u => u.Id == Id && u.AppUserId == user.Id).FirstOrDefaultAsync();
            if (todo == null)
            {
                throw new Exception("Todo does not exist");
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return new TodoDTO()
            {
                TaskName = todo.TaskName,
                TaskSort = todo.TaskSort,
                IsCompleted = todo.IsCompleted,
                TodoCategoryId = todo.TodoCategoryId
            };
        }

        public async Task<List<TodoDTO>> GetAll()
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var todos = await _context.Todos.Where(u => u.AppUserId == user.Id).ToListAsync();
            List<TodoDTO> res = new List<TodoDTO>();
            foreach(var todo in todos)
            {
                var todoDTO = new TodoDTO()
                {
                    TaskName = todo.TaskName,
                    TaskSort = todo.TaskSort,
                    IsCompleted = todo.IsCompleted,
                    TodoCategoryId = todo.TodoCategoryId,
                    Id = todo.Id
                };
                res.Add(todoDTO);
            }
            return res;
        }

        public async Task<TodoDTO> GetById(Guid Id)
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var todo = await _context.Todos.Where(u => u.Id == Id && u.AppUserId == user.Id).FirstOrDefaultAsync();
            if (todo == null)
            {
                throw new Exception($"No todo found with id {Id}");
            }
            return new TodoDTO()
            {
                TaskName = todo.TaskName,
                TaskSort = todo.TaskSort,
                IsCompleted = todo.IsCompleted,
                TodoCategoryId = todo.TodoCategoryId,
                Id = todo.Id
            };
        }

        public async Task<TodoDTO> Update(TodoDTO TodoDTO)
        {
            var user = await _userGetter.GetCurrentUserAsync();
            var todo = await _context.Todos.Where(u => u.Id == TodoDTO.Id && u.AppUserId == user.Id).FirstOrDefaultAsync();
            if (todo == null)
            {
                throw new Exception($"No todo found with id {TodoDTO.Id}");
            }
            todo.TaskName = TodoDTO.TaskName;
            todo.TodoCategoryId = TodoDTO.TodoCategoryId;
            todo.IsCompleted = TodoDTO.IsCompleted;
            todo.TaskSort = TodoDTO.TaskSort;
            await _context.SaveChangesAsync();
            return new TodoDTO()
            {
                TaskName = todo.TaskName,
                TaskSort = todo.TaskSort,
                IsCompleted = todo.IsCompleted,
                TodoCategoryId = todo.TodoCategoryId,
                Id = todo.Id
            };

        }
    }
}
