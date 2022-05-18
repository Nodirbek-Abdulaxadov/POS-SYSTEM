using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Inventory
{
    public class Supplier
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
