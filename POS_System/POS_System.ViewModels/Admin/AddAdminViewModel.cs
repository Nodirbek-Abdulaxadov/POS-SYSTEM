using System.ComponentModel.DataAnnotations;


namespace POS_System.ViewModels.Admin
{
    public class AddAdminRole
    {
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
    }
}
