using Microsoft.EntityFrameworkCore;
using POS_System.Data;
using POS_System.Domains.Pagination;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Selling;

namespace POS_System.Repositories.Repos.Selling
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

        public Task<PagedList<Department>> GetDepartments(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Department>.ToPagedList(_dbContext.Departments.OrderBy(d => d.Name), parameters.PageNumber, parameters.PageSize));
        }

        public Task<List<Department>> GetDepartmentsAsync() =>

          Task.FromResult(_dbContext.Departments.OrderBy(d => d.Name).ToList());



        public Task<bool> IsNameExist(string Name)
        {
            return Task.FromResult(_dbContext.Departments.Any(d => d.Name == Name)); }

        public Task<Department> UpdateDepartmentAsync(Department department)
        {
            _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();
            return Task.FromResult(department);
        }
    }
      
    
}
