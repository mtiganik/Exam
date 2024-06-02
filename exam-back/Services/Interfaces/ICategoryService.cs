using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Guid> CreateCategory(CategoryDTO category);
        Task DeleteCategory(Guid categoryId);
        Task<CategoryDTO> GetCategoryById(Guid categoryId);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();

    }
}
