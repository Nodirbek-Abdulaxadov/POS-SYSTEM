using POS_System.Domains.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Inventory
{
    public class AddLoanForInventoryViewModel
    {
        public DateTime DateTime { get; set; }
        [Required]
        public double PaidPrice { get; set; }
        [Required]
        public double LeftPrice { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public Guid SupplierId { get; set; }
        public Guid TransactionId { get; set; }


        public static explicit operator LoanForInventory(AddLoanForInventoryViewModel viewModel)
        {
            return new LoanForInventory
            {
                Id = Guid.NewGuid(),
                PaidPrice = viewModel.PaidPrice,
                LeftPrice = viewModel.LeftPrice,
                IsPaid = viewModel.IsPaid,
                SupplierId = viewModel.SupplierId,
                TransactionId = viewModel.TransactionId,

            };
            

        }

    }
}
