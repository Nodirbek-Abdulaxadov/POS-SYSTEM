using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddSellingProccessViewModel
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double ProccessIncomingPrice { get; set; }
        [Required]
        public double ProccessSellingPrice { get; set; }
        [Required]
        public Guid OrderId { get; set; }
    }
}

