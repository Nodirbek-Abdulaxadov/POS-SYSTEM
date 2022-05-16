using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Client
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
