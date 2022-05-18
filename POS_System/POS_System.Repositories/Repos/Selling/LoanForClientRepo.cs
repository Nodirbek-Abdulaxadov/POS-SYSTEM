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
    public class LoanForClientRepo : ILoanForClientInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanForClientRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<LoanForClient> AddLoanForClientAsync(LoanForClient loanForClient)
        {
            _dbContext.LoanForClients.Add(loanForClient);
            _dbContext.SaveChanges();
            return Task.FromResult(loanForClient);
        }

        public Task DeleteLoanForClientAsync(Guid loanforclienId)
        {
            _dbContext.LoanForClients.Remove(_dbContext.LoanForClients.FirstOrDefault(p => p.Id == loanforclienId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<LoanForClient>> GetAllClientLoansByClientId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LoanForClient>> GetAllClientsLoans()
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<LoanForClient>> GetAllClientsLoansPaged()
        {
            throw new NotImplementedException();
        }

        public Task<LoanForClient> GetClientLoanByClientId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanForClient> GetClientLoanByLoanId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId) =>
            _dbContext.LoanForClients.FirstOrDefaultAsync(p => p.Id == loanforclientId);

        public Task<List<LoanForClient>> GetLoanForClientsAsync() =>
            _dbContext.LoanForClients.ToListAsync();

        public Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient)
        {
            _dbContext.LoanForClients.Update(loanForClient);
            _dbContext.SaveChanges();
            return Task.FromResult(loanForClient);
        }
    }
}
