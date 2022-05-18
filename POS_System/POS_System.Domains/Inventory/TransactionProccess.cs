using System.ComponentModel.DataAnnotations;

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
    }
}
