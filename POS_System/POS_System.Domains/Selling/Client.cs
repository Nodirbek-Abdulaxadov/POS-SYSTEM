using POS_System.ViewModels.Selling;
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

        public static explicit operator Client(AddClientViewModel viewModel)
        {
            return new Client
            {
                Id = Guid.NewGuid(),
                FullName = viewModel.FullName,
                Adress = viewModel.Adress,
                PhoneNumber = viewModel.PhoneNumber,
            };
        }
    }
}
