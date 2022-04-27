using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces;

namespace POS_System.Repositories.Repos
{
    public class DepartmentRepo : IDepartmentInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Department> AddDepartmentAsync(Department department)
        {
            _dbContext.Departments.AddAsync(department);
            _dbContext.SaveChanges();
            return Task.FromResult(department);
        }

        public Task DeleteDepartmentAsync(Guid departmentId)
        {
            _dbContext.Departments.Remove(_dbContext.Departments.FirstOrDefault(p => p.Id == departmentId));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<Department> GetDepartmentByIdAsync(Guid id) => 
            _dbContext.Departments.FirstOrDefaultAsync(p => p.Id == id);

        public Task<List<Department>> GetDepartmentsAsync() =>
            _dbContext.Departments.ToListAsync();

        public Task<Department> UpdateDepartmentAsync(Department department)
        {
            _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();
            return Task.FromResult(department);
        }
    }
}
