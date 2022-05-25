using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class LoanForClient
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
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
