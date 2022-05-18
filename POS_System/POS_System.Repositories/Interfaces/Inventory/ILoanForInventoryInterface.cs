using POS_System.Domains.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Repositories.Interfaces.Inventory
{
    public interface ILoanForInventoryInterface
    {
        Task<List<LoanForInventory>> GetLoanForInventorysAsync();
        Task<LoanForInventory> GetLoanForInventoryAsync(Guid loanforinventoryId);
        Task<LoanForInventory> AddLoanForInventoryAsync(LoanForInventory loanForInventory);
        Task<LoanForInventory> UpdateLoanForInventoryAsync(LoanForInventory loanForInventory);
        Task DeleteLoanForInventoryAsync(Guid loanforinventoryId);
    }
}
