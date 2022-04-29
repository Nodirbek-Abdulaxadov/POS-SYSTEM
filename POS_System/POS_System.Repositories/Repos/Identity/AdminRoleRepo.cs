using POS_System.Domains.Admin;

namespace POS_System.Repositories.Repos.Identity
{
    public interface AdminRoleRepo
    {
        Task<List<AdminRole>> GetCategoriesAsync();
        Task<AdminRole> GetAdminRoleAsync(Guid adminRoleId);
        Task<AdminRole> AddAdminRoleAsync(AdminRole adminRole);
        Task<AdminRole> UpdateAdminRoleAsync(AdminRole adminRole);
        Task DeleteAdminRoleAsync(Guid adminRoleId);
    }
}
