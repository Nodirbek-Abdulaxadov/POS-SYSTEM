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
    public class ProductRepo : IProductInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Product> AddProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return Task.FromResult(product);
        }

        public Task DeleteProductAsync(Guid productId)
        {
            _dbContext.Products.Remove(_dbContext.Products.FirstOrDefault(p => p.Id == productId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Product> GetProductAsync(Guid productId) =>
            _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

        public Task<PagedList<Product>> GetProducts(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Product>.ToPagedList(_dbContext.Products.OrderBy(p => p.Name), parameters.PageNumber, parameters.PageSize));
        }

        public Task<List<Product>> GetProductsAsync() =>
            _dbContext.Products.OrderBy(p => p.Name).ToListAsync();

        public Task<Product> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return Task.FromResult(product);
        }
    }
}
