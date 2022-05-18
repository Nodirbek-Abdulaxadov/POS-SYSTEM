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
    }
}
