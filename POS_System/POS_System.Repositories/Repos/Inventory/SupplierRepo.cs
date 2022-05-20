using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;
using POS_System.Repositories.Interfaces.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Repos.Inventory
{
    public class SupplierRepo : ISupplierInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            return Task.FromResult(supplier);
        }

        public Task DeleteSupplierAsync(Guid supplierId)
        {
            _dbContext.Suppliers.Remove(_dbContext.Suppliers.FirstOrDefault(p => p.Id == supplierId));
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<PagedList<Supplier>> GetAllSuppliers(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Supplier>.ToPagedList(_dbContext.Suppliers, parameters.PageNumber, parameters.PageSize));
        }

        public Task<Supplier> GetSupplierAsync(Guid supplierId) =>
            _dbContext.Suppliers.FirstOrDefaultAsync(p => p.Id == supplierId);


        public Task<List<Supplier>> GetSuppliersAsync() =>
            _dbContext.Suppliers.ToListAsync();

        public Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            _dbContext.SaveChanges();
            return Task.FromResult(supplier);
        }
    }
}
