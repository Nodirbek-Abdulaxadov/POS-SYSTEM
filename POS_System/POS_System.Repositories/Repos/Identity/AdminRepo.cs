using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Admin;
using POS_System.Repositories.Interfaces.Identity;

namespace POS_System.Repositories.Repos.Identity
{
    public class AdminRepo : IAdminInterface
    {
        private readonly IdentityDbContext _dbContext;

        public AdminRepo(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;  
        }

        public async Task<(Result, Guid)> AuthorizeAsync(string phoneNumber, string password)
        {
            Admin admin = await _dbContext.Admins.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber && x.Password == password);  
            if (admin != null)
            {
                return (Result.Success(), admin.Id);
            }
            
            return (Result.Failure("Incorrect phone number or password "), Guid.Empty);
        }

        public Task<Admin> CreateAdminAsync(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();

            return Task.FromResult(admin);
        }

        public Task DeleteAsync(Guid id)
        {
            var admin = _dbContext.Admins.FirstOrDefault(x => x.Id == id);
            _dbContext.Admins.Remove(admin);

            return Task.CompletedTask;
        }

        public Task<Admin> GetAdminByIdAsync(Guid id) =>
            Task.FromResult(_dbContext.Admins.FirstOrDefault(ad => ad.Id == id));

        public Task<List<Admin>> GetAdminsAsync() =>
            _dbContext.Admins.ToListAsync();
        public Task<bool> IsInRoleAsync(Guid id, string roleName)
        {
            Admin admin = _dbContext.Admins.FirstOrDefault(ad => ad.Id == id);
            AdminRole role = _dbContext.Roles.FirstOrDefault(x => x.Name == roleName);

            if (admin != null && role != null)
            {
                return Task.FromResult(admin.AdminRoleId == role.Id);
            }

            return Task.FromResult(false);
        }

        public Task<Admin> UpdateAdminAsync(Admin admin)
        {
            _dbContext.Admins.Update(admin);
            _dbContext.SaveChanges();

            return Task.FromResult(admin);
        }
    }
}
