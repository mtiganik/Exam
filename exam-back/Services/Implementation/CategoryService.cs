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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateCategory(CategoryDTO dto)
        {
            Guid id = (Guid)(dto.Id == null ? Guid.NewGuid() : dto.Id);
            TodoCategory category = new TodoCategory()
            {
                Id = id,
                CategoryName = dto.CategoryName,
                CategorySort = dto.CategorySort == null ? 0 : dto.CategorySort
            };
            await _context.TodoCategories.AddRangeAsync(category);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var cat = await _context.TodoCategories.Where(u => u.Id == categoryId).FirstOrDefaultAsync();
            if (cat == null)
            {
                throw new Exception($"Category with id {categoryId} does not exist");
            }
            _context.TodoCategories.Remove(cat);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var entities = await _context.TodoCategories.ToListAsync();
            var res = new List<CategoryDTO>();
            foreach (var category in entities)
            {
                var categoryDTO = new CategoryDTO()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CategorySort = category.CategorySort,
                };
                res.Add(categoryDTO);
            }
            return res;
        }

        public async Task<CategoryDTO> GetCategoryById(Guid categoryId)
        {
            var cat = await _context.TodoCategories.Where(u => u.Id == categoryId).FirstOrDefaultAsync();
            return new CategoryDTO()
            {
                Id = cat.Id,
                CategoryName = cat.CategoryName,
                CategorySort = cat.CategorySort,
            };
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO category)
        {
            var cat = await _context.TodoCategories.Where(u => u.Id == category.Id).FirstOrDefaultAsync();
            if(cat == null)
            {
                throw new Exception($"No category with id {category.Id}");
            }
            cat.CategorySort = category.CategorySort;
            cat.CategoryName = category.CategoryName;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
