using POS_System.ViewModels.Admin;

namespace POS_System.Domains.Admin
{
    public class AdminRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator AdminRole(AddAdminRoleViewModel v)
        {
            return new AdminRole()
            {
                Id = Guid.NewGuid(),
                Name = v.Name,
            };
        }
    }
}
