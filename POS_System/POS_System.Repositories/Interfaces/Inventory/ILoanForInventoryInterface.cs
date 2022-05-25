using POS_System.Domains.Inventory;
using POS_System.Domains.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Inventory
{
    public interface ILoanForInventoryInterface
    {
<<<<<<< HEAD
        Task<PagedList<LoanForInventory>> GetAllLoanForInventorys(QueryStringParameters parameters);
=======
        Task<PagedList<LoanForInventory>> GetAllLoanForInventorysAsync(QueryStringParameters parameters);
>>>>>>> e6f981273b7a3defb60d85f03696f3becb637502
        Task<List<LoanForInventory>> GetLoanForInventorysAsync();
        Task<LoanForInventory> GetLoanForInventoryAsync(Guid loanforinventoryId);
        Task<LoanForInventory> AddLoanForInventoryAsync(LoanForInventory loanForInventory);
        Task<LoanForInventory> UpdateLoanForInventoryAsync(LoanForInventory loanForInventory);
        Task DeleteLoanForInventoryAsync(Guid loanforinventoryId);
    }
}
