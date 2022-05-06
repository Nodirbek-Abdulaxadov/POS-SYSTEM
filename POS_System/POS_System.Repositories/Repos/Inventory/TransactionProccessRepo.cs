using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Inventory;
using POS_System.Repositories.Interfaces.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Inventory
{
    public class TransactionProccessRepo : ITransactionProccessInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionProccessRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TransactionProccess> AddTransactionProccessAsync(TransactionProccess transactionproccess)
        {
            _dbContext.TransactionProccesses.Add(transactionproccess);
            _dbContext.SaveChanges();
            return Task.FromResult(transactionproccess);
        }

        public Task DeleteTransactionProccessAsync(Guid transactionproccessId)
        {
            _dbContext.TransactionProccesses.Remove(_dbContext.TransactionProccesses.FirstOrDefault(p => p.Id == transactionproccessId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<TransactionProccess>> GetAllTransactionProccessAsync() =>
            _dbContext.TransactionProccesses.ToListAsync();

        public Task<TransactionProccess> GetTransactionProccessAsync(Guid transactionproccessId) =>
            _dbContext.TransactionProccesses.FirstOrDefaultAsync(p => p.Id == transactionproccessId);

        public Task<TransactionProccess> UpdateTransactionProccessAsync(TransactionProccess transactionproccess)
        {
            _dbContext.TransactionProccesses.Update(transactionproccess);
            _dbContext.SaveChanges();
            return Task.FromResult(transactionproccess);
        }
    }
}
