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
<<<<<<< HEAD
        Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters);
        Task<List<LoanForClient>> GetLoanForClientsAsync();
        Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId);
=======
        Task<List<LoanForClient>> GetAllClientsLoans();
        Task<PagedList<LoanForClient>> GetAllClientsLoansPaged();
        Task<List<LoanForClient>> GetAllClientLoansByClientId(Guid id);
        Task<LoanForClient> GetClientLoanByLoanId(Guid id);
        Task<LoanForClient> GetClientLoanByClientId(Guid id);
>>>>>>> b311fa986d7499b34f282e41b2dc5b713b797deb
        Task<LoanForClient> AddLoanForClientAsync(LoanForClient loanForClient);
        Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient);
        Task DeleteLoanForClientAsync(Guid loanforclienId);
    }
}
