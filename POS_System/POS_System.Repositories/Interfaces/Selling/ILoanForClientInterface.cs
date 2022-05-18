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
        Task<List<LoanForClient>> GetAllClientsLoans();
        Task<PagedList<LoanForClient>> GetAllClientsLoansPaged();
        Task<List<LoanForClient>> GetAllClientLoansByClientId(Guid id);
        Task<LoanForClient> GetClientLoanByLoanId(Guid id);
        Task<LoanForClient> GetClientLoanByClientId(Guid id);
        Task<LoanForClient> AddLoanForClientAsync(LoanForClient loanForClient);
        Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient);
        Task DeleteLoanForClientAsync(Guid loanforclienId);
    }
}
