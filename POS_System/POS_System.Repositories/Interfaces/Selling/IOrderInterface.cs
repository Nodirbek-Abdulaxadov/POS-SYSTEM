using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface IOrderInterface
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid orderId);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid orderId);
    }
}
