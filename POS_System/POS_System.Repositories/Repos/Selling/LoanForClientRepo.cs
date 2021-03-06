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


        public Task<List<LoanForClient>> GetAllClientLoansByClientId(Guid id) =>
               _dbContext.LoanForClients.Where(l => l.ClientId == id).ToListAsync();


        public Task<List<LoanForClient>> GetAllClientsLoans()
        {

            throw new NotImplementedException();

            

        }

        public Task<PagedList<LoanForClient>> GetAllClientsLoansPaged()
        {
            throw new NotImplementedException();
        }

        public Task<LoanForClient> GetLoanByOrderId(Guid orderId)
        {
            throw new NotImplementedException();

        }
        public Task<LoanForClient> GetClientLoanByLoanId(Guid id)
        {
            var loan = _dbContext.LoanForClients.FirstOrDefault(l => l.OrderId == id);

            return Task.FromResult(loan);

        }

        public Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId) =>
            _dbContext.LoanForClients.FirstOrDefaultAsync(p => p.Id == loanforclientId);

        public Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<LoanForClient>.ToPagedList(_dbContext.LoanForClients.OrderBy(l => l.Date), parameters.PageNumber, parameters.PageSize));
        }

        public Task<List<LoanForClient>> GetLoanForClientsAsync() =>

            _dbContext.LoanForClients.OrderBy(p => p.ClientId).ToListAsync();




        public Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient)
        {
            _dbContext.LoanForClients.Update(loanForClient);
            _dbContext.SaveChanges();
            return Task.FromResult(loanForClient);
        }
    }
}
