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
    public class OrderRepo : IOrderInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Category> AddOrderAsync(Category order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return Task.FromResult(order);
        }

        public Task DeleteOrderAsync(Guid orderId)
        {
            _dbContext.Orders.Remove(_dbContext.Orders.FirstOrDefault(p => p.Id == orderId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Category> GetOrderAsync(Guid orderId) =>
            _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == orderId);

        public Task<PagedList<Category>> GetOrders(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Category>.ToPagedList(_dbContext.Orders, parameters.PageNumber, parameters.PageSize));
        }

        public Task<List<Category>> GetOrdersAsync() =>
            _dbContext.Orders.ToListAsync();

        public Task<Category> UpdateOrderAsync(Category order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return Task.FromResult(order);
        }
    }
}
