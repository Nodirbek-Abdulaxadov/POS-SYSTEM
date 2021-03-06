using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Repositories.Interfaces.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;

namespace POS_System.Repositories.Repos.Inventory
{
    public class TransactionRepo : ITransactionInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            return Task.FromResult(transaction);
        }

        public Task DeleteTransactionAsync(Guid transactionId)
        {
            _dbContext.Transactions.Remove(_dbContext.Transactions.FirstOrDefault(p => p.Id == transactionId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<PagedList<Transaction>> GetAllTransactions(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Transaction>.ToPagedList(_dbContext.Transactions, parameters.PageNumber, parameters.PageSize));
        }

        public Task<Transaction> GetTransactionAsync(Guid transactionId) =>
            _dbContext.Transactions.FirstOrDefaultAsync(p => p.Id == transactionId);

        public Task<List<Transaction>> GetTransactionsAsync() =>
            _dbContext.Transactions.ToListAsync();

        public Task<Transaction> UpdateTransactionAsync(Transaction transaction)
        {
            _dbContext.Transactions.Update(transaction);
            _dbContext.SaveChanges();
            return Task.FromResult(transaction);
        }
    }
}
