using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IOrderInterface
    {
        Task<PagedList<Order>> GetOrders(QueryStringParameters parameters);
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid orderId);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid orderId);
    }
}
