using POS_System.Domains.Admin;

namespace POS_System.Repositories.Interfaces.Identity
{
    public interface IAdminInterface
    {
        Task<Admin> GetAdminByIdAsync(Guid id);
        Task<Admin> CreateAdminAsync(Admin admin);
        Task<Admin> UpdateAdminAsync(Admin admin);
        Task DeleteAsync(Guid id);
        Task<bool> IsInRoleAsync(Guid id, string roleName);
        Task<(Result, Guid)> AuthorizeAsync(string phoneNumber, string password);
    }
}
