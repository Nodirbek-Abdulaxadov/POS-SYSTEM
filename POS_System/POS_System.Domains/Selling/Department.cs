using POS_System.Domains.Selling;
using POS_System.ViewModels.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Selling
{
    public class Department
    {
        [Key, Required]
        public Guid Id { get; set; }
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
