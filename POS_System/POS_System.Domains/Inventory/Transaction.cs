using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Inventory
{
    public class Transaction
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public Guid SupplierId { get; set; }
        public Guid TransactionProccessId { get; set; }
        public Guid AdminId { get; set; }
    }
}
