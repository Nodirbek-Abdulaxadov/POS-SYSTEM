using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Category
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
    }
}
