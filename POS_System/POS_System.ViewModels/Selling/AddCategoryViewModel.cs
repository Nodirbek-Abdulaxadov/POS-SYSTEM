using System.ComponentModel.DataAnnotations;
namespace POS_System.ViewModels.Selling
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
    }
}
