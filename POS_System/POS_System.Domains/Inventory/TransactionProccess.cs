using POS_System.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Inventory
{
    public class TransactionProccess
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public Guid ProductId { get; set; }

        public static explicit operator TransactionProccess(AddTransactionProccessViewModel viewModel)
        {
            return new TransactionProccess()
            {
                Id = Guid.NewGuid(),
                Quantity = viewModel.Quantity,
                TotalPrice = viewModel.TotalPrice,
                ProductId = viewModel.ProductId,
            };
        }
    }
}
