using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Selling
{
    public class CategoryRepo : ICategoryInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Category> AddCategoryAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Task.FromResult(category);
        }

        public Task DeleteCategoryAsync(Guid categoryId)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(p => p.Id == categoryId));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<PagedList<Category>> GetCategories(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Category>.ToPagedList(_dbContext.Categories, parameters.PageNumber, parameters.PageSize));
        }
    

        public Task<List<Category>> GetCategoriesAsync() =>
            _dbContext.Categories.ToListAsync();

        public Task<Category> GetCategoryAsync(Guid categoryId) =>
            _dbContext.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);

        public Task<Category> UpdateCategoryAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
            return Task.FromResult(category);
        }
    }
}
