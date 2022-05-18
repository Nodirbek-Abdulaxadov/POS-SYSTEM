using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface ICategoryInterface
    {
        Task<PagedList<Category>> GetCategories(QueryStringParameters parameters);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid categoryId);
    }
}
