﻿using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces.Selling
{
    public interface ILoanForClientInterface
    {
        Task<PagedList<LoanForClient>> GetLoanForClients(QueryStringParameters parameters);
        Task<List<LoanForClient>> GetLoanForClientsAsync();
        Task<LoanForClient> GetLoanForClientAsync(Guid loanforclientId);
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
