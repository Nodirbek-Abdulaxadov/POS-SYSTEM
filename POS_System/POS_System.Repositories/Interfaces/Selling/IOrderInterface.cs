using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IOrderInterface
    {
        Task<PagedList<Category>> GetOrders(QueryStringParameters parameters);
        Task<List<Category>> GetOrdersAsync();
        Task<Category> GetOrderAsync(Guid orderId);
        Task<Category> AddOrderAsync(Category order);
        Task<Category> UpdateOrderAsync(Category order);
        Task DeleteOrderAsync(Guid orderId);
    }
}
