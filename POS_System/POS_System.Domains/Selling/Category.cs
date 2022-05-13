using POS_System.ViewModels.Selling;
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

        public static explicit operator Category(AddCategoryViewModel viewModel)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                DepartmentId = viewModel.DepartmentId
            };
        }

        public static explicit operator Category(AddClientViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
