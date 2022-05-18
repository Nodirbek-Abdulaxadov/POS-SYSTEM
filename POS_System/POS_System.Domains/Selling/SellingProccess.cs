using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class SellingProccess
    {
        [Key, Required]
        public Guid Id { get; set; }
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
