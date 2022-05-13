using System.ComponentModel.DataAnnotations;
namespace POS_System.ViewModels.Selling
{
    public class AddClientViewModel
    {
        [Required]
      
        public string? FullName { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
