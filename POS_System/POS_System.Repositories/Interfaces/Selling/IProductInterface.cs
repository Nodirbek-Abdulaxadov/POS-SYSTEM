using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IProductInterface
    {

        Task<PagedList<Product>> GetProducts(QueryStringParameters parameters);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid productId);
    }
}
