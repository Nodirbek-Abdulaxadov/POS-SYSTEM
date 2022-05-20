using POS_System.Domains.Selling;
using System.ComponentModel.DataAnnotations;

namespace POS_System.ViewModels.Selling
{
    public class AddClientViewModel
    {
        public string? FullName { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }

        public static explicit operator Client(AddClientViewModel v)
        {
            return new Client()
            {
                FullName = v.FullName,
                Adress = v.Adress,
                PhoneNumber = v.PhoneNumber,
                Id = Guid.NewGuid(),
                HasLoan = false
            };
        }
    }
}
