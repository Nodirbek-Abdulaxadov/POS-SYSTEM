using POS_System.Domains.Selling;

namespace POS_System.Repositories.Interfaces
{
    public interface IDepartmentInterface
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(Guid id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Guid departmentId);
    }
}
