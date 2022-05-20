using POS_System.Domains.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Inventory
{
    public class AddTransactionProccessViewModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public Guid ProductId { get; set; }

        public static explicit operator TransactionProccess(AddTransactionProccessViewModel v)
        {
            return new TransactionProccess()
            {
                Quantity = v.Quantity,
                TotalPrice = v.TotalPrice,
                ProductId = v.ProductId

            };
        }
    }
}
