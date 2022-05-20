using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface ILoanForClientInterface
    {
        //barcha qarzlarni paged list holatida qaytaradi
        Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters);
        //barcha qarzlarni qaytaradi
        Task<List<LoanForClient>> GetLoanForClientsAsync();
        //orderId bo'yicha loan qaytaradi
        Task<LoanForClient> GetLoanByOrderId(Guid orderId);
        //id bo'yicha qarzni qaytaradi
        Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId);
        //mijozning barcha qarzlarini mijozId bo'yicha qayataradi
        Task<List<LoanForClient>> GetAllClientLoansByClientId(Guid id);
        //mijozning barcha qarzlarini mijozId bo'yicha paged holatida qayataradi
        Task<PagedList<LoanForClient>> GetAllClientsLoansPaged();
        Task<LoanForClient> AddLoanForClientAsync(LoanForClient loanForClient);
        Task<LoanForClient> UpdateLoanForClientAsync(LoanForClient loanForClient);
        Task DeleteLoanForClientAsync(Guid loanforclienId);
    }
}
