using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Department
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
