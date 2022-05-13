using POS_System.Domains.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Inventory
{
    public class LoanForInventory
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double PaidPrice { get; set; }
        [Required]
        public double LeftPrice { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public Guid SupplierId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
