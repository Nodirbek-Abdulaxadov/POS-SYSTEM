using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;

namespace POS_System.Repositories.Interfaces.Inventory
{
    public interface ITransactionInterface
    {
        Task<PagedList<Transaction>> GetAllTransactions(QueryStringParameters parameters);
        Task<List<Transaction>> GetTransactionsAsync();
        Task<Transaction> GetTransactionAsync(Guid transactionId);
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<Transaction> UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(Guid transactionId);
    }
}
