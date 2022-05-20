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
    public class SellingProccessRepo : ISellingProccessInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public SellingProccessRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<SellingProccess> AddSellingProccessAsync(SellingProccess sellingProccess)
        {
            _dbContext.SellingProccesses.Add(sellingProccess);
            _dbContext.SaveChanges();
            return Task.FromResult(sellingProccess);
        }

        public Task DeeleteSellingProccessAsync(Guid sellingproccessId)
        {
            _dbContext.SellingProccesses.Remove(_dbContext.SellingProccesses.FirstOrDefault(p => p.Id == sellingproccessId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<SellingProccess>> GetAllSellingProccessAsync() =>
            _dbContext.SellingProccesses.ToListAsync();

     

        public Task<SellingProccess> GetSellingProccessAsync(Guid sellingproccessId) =>
            _dbContext.SellingProccesses.FirstOrDefaultAsync(p => p.Id == sellingproccessId);

        public Task<PagedList<SellingProccess>> GetSellingProccesses(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<SellingProccess>.ToPagedList(_dbContext.SellingProccesses, parameters.PageNumber, parameters.PageSize));
        }


        public Task<SellingProccess> UpdateSellingProccessAsync(SellingProccess sellingProccess)
        {
            _dbContext.SellingProccesses.Update(sellingProccess);
            _dbContext.SaveChanges();
            return Task.FromResult(sellingProccess);
        }
    }
}
