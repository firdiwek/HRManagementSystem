// HR.Management.Application/Interfaces/IDepartmentRepository.cs
using HR.Management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Application.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
