using POS_System.ViewModels.Admin;
using System.ComponentModel.DataAnnotations;

namespace POS_System.Domains.Admin
{
    public class Admin
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid AdminRoleId { get; set; }

        public static explicit operator Admin(AddAdminViewModel viewModel)
        {
            return new Admin()
            {
                Id = Guid.NewGuid(),
                FullName = viewModel.FullName,
                PhoneNumber = viewModel.PhoneNumber,
                Adress = viewModel.Adress,
                Password = viewModel.Password,
                AdminRoleId = viewModel.AdminRoleId
            };
        }

        public static explicit operator AddAdminViewModel(Admin viewModel)
        {
            return new AddAdminViewModel()
            {

            };
        }
    }
}
