using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Order
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalIncomingPrice { get; set; }
        [Required]
        public double TotalSellingPrice { get; set; }
        [Required]
        public string PaymentMehtod { get; set; }
        [Required]
        public bool HasLoan { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
    }
}
