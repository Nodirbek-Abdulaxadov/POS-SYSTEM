using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Selling
{
    public class OrderRepo : IOrderInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AddOrderViewModel> AddOrderAsync(AddOrderViewModel order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return Task.FromResult(order);
        }

        public Task<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(Guid orderId)
        {
            _dbContext.Orders.Remove(_dbContext.Orders.FirstOrDefault(p => p.Id == orderId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<AddOrderViewModel> GetOrderAsync(Guid orderId) =>
            _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == orderId);

        public Task<List<AddOrderViewModel>> GetOrdersAsync() =>
            _dbContext.Orders.ToListAsync();

        public Task<AddOrderViewModel> UpdateOrderAsync(AddOrderViewModel order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return Task.FromResult(order);
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderInterface.GetOrderAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IOrderInterface.GetOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
