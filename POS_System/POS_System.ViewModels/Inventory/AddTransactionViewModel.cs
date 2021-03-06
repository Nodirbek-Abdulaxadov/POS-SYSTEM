using POS_System.Domains.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Inventory
{
    public class AddTransactionViewModel
    {
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public Guid SupplierId { get; set; }
        public Guid TransactionProccessId { get; set; }
        public Guid AdminId { get; set; }


        public static explicit operator Transaction(AddTransactionViewModel viewModel)
        {
            return new Transaction()
            {
                TotalPrice = viewModel.TotalPrice,
                DateTime = viewModel.DateTime,
                SupplierId = viewModel.SupplierId,
                TransactionProccessId = viewModel.TransactionProccessId,
                AdminId = viewModel.AdminId,
                
            };
        }
    }
}
