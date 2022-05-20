using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;
using POS_System.Repositories.Interfaces.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Inventory
{
    public class LoanForInventoryRepo : ILoanForInventoryInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanForInventoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<LoanForInventory> AddLoanForInventoryAsync(LoanForInventory loanForInventory)
        {
            _dbContext.LoanForInventorys.Add(loanForInventory);
            _dbContext.SaveChanges();
            return Task.FromResult(loanForInventory);
        }

        public Task DeleteLoanForInventoryAsync(Guid loanforinventoryId)
        {
            _dbContext.LoanForInventorys.Remove(_dbContext.LoanForInventorys.FirstOrDefault(p => p.Id == loanforinventoryId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<PagedList<LoanForInventory>> GetAllLoanForInventorysAsync(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<LoanForInventory>.ToPagedList(_dbContext.LoanForInventorys, parameters.PageNumber, parameters.PageSize));
        }

        public Task<LoanForInventory> GetLoanForInventoryAsync(Guid loanforinventoryId) =>
            _dbContext.LoanForInventorys.FirstOrDefaultAsync(p => p.Id == loanforinventoryId);

        public Task<List<LoanForInventory>> GetLoanForInventorysAsync() =>
            _dbContext.LoanForInventorys.ToListAsync();

        public Task<LoanForInventory> UpdateLoanForInventoryAsync(LoanForInventory loanForInventory)
        {
            _dbContext.LoanForInventorys.Update(loanForInventory);
            _dbContext.SaveChanges();
            return Task.FromResult(loanForInventory);
        }
    }
}
