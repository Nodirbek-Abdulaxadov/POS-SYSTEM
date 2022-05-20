using POS_System.Domains.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.ViewModels.Selling
{
    public class AddDepartmentViewModel
    {
        
        [Required]
        public string? Name { get; set; }

        public static explicit operator Department(AddDepartmentViewModel viewModel)
        {
            return new Department
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,

            };
        }
    }
}
