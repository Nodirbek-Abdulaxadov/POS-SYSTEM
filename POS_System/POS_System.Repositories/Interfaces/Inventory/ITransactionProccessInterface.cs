using POS_System.Domains.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Inventory
{
    public interface ITransactionProccessInterface
    {
        Task<List<TransactionProccess>> GetAllTransactionProccessAsync();
        Task<TransactionProccess> GetTransactionProccessAsync(Guid transactionproccessId);
        Task<TransactionProccess> AddTransactionProccessAsync(TransactionProccess transactionproccess);
        Task<TransactionProccess> UpdateTransactionProccessAsync(TransactionProccess transactionproccess);
        Task DeleteTransactionProccessAsync(Guid transactionproccessId);
    }
}
