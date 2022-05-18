using POS_System.Domains.Selling;
using System.ComponentModel.DataAnnotations;
namespace POS_System.ViewModels.Selling
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }

        public static explicit operator Category(AddCategoryViewModel viewModel)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                DepartmentId = viewModel.DepartmentId
            };
        }
    }
}
