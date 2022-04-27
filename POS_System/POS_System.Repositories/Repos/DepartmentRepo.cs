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
            throw new NotImplementedException();
        }

        public Task DeleteDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetDepartmentsAsync() =>
            _dbContext.Departments.ToListAsync();

        public Task<Department> UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
