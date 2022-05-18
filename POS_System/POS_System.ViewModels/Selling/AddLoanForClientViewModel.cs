using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.ViewModels.Selling
{
    public class AddLoanForClientViewModel
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public double PaidPrice { get; set; }
        [Required]
        public double LeftPrice { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid OrderId { get; set; }
    }
}
