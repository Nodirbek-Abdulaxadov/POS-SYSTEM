using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Inventory
{
    public interface ISupplierInterface
    {
        Task<PagedList<Supplier>> GetAllSuppliers(QueryStringParameters parameters);
        Task<List<Supplier>> GetSuppliersAsync();
        Task<Supplier> GetSupplierAsync(Guid supplierId);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task DeleteSupplierAsync(Guid supplierId);
    }
}
