using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface ILoanForClientInterface
    {
        Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters);
        Task<List<LoanForClient>> GetLoanForClientsAsync();
        Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId);
        Task<LoanForClient> AddLoanForClientAsync(LoanForClient loanForClient);
        Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient);
        Task DeleteLoanForClientAsync(Guid loanforclienId);
    }
}
