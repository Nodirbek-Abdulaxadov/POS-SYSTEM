using System.ComponentModel.DataAnnotations;

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
