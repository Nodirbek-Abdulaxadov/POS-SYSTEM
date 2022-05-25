using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;

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
            return Task.FromResult(_dbContext.LoanForClients.Where(l => l.ClientId == id).ToList());
        }

        public Task<PagedList<LoanForClient>> GetAllClientsLoansPaged()
        {
            throw new NotImplementedException();
        }

        public Task<LoanForClient> GetLoanByOrderId(Guid orderId)
        {
            var loan = _dbContext.LoanForClients.FirstOrDefault(l => l.OrderId == orderId);

            return Task.FromResult(loan);
        }

        public Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId) =>
            _dbContext.LoanForClients.FirstOrDefaultAsync(p => p.Id == loanforclientId);

        public Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<LoanForClient>.ToPagedList(_dbContext.LoanForClients, parameters.PageNumber, parameters.PageSize));
        }

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
