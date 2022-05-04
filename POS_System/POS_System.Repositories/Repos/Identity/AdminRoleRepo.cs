using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Admin;
using POS_System.Repositories.Interfaces.Identity;

namespace POS_System.Repositories.Repos.Identity
{
    public class AdminRoleRepo : IAdminRoleInterface
    {

        private readonly IdentityDbContext _dbContext;

        public AdminRoleRepo(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<AdminRole> AddAdminRoleAsync(AdminRole adminRole)
        {
            _dbContext.Roles.Add(adminRole);
            _dbContext.SaveChanges();

            return Task.FromResult(adminRole);
        }

        public Task DeleteAdminRoleAsync(Guid adminRoleId)
        {
            _dbContext.Remove(_dbContext.Roles.FirstOrDefault(r => r.Id == adminRoleId));
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<AdminRole> GetAdminRoleAsync(Guid adminRoleId) =>
             _dbContext.Roles.FirstOrDefaultAsync(roles => roles.Id == adminRoleId);

        public Task<List<AdminRole>> GetAdminRolesAsync() => 
            _dbContext.Roles.ToListAsync();

        public Task<AdminRole> UpdateAdminRoleAsync(AdminRole adminRole)
        {
            _dbContext.Roles.Update(adminRole);
            _dbContext.SaveChanges();

            return Task.FromResult(adminRole);
        }
    }
}
