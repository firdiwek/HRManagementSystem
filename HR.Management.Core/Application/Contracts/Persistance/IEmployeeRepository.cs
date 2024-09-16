using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Management.Domain;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Contracts.Persistence
{
    /// <summary>
    /// Interface for Employee repository operations.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee with the specified ID.</returns>
        Task<Employee?> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        /// <summary>
        /// Add a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The added employee.</returns>
        Task<Employee> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Update an existing employee.
        /// </summary>
        /// <param name="employee">The employee to update.</param>
        /// <returns>A boolean indicating whether the update was successful.</returns>
        Task<bool> UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Delete an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteEmployeeByIdAsync(int id);

        /// <summary>
        /// Get employees by department ID.
        /// </summary>
        /// <param name="departmentId">The department ID to filter employees by.</param>
        /// <returns>A lidotnetst of employees in the specified department.</returns>
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);

        /// <summary>
        /// Get employees by manager ID.
        /// </summary>
        /// <param name="managerId">The manager ID to filter employees by.</param>
        /// <returns>A list of employees managed by the specified manager.</returns>
        Task<IEnumerable<Employee>> GetEmployeesByManagerIdAsync(int? managerId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartementAsync(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByName(string name);
        Task<PagedResult<Employee>> GetPagedEmployeesAsync(int page, int pagesize);
        Task<PagedResult<Employee>> GetTotalEmployeesCountAsync();
        
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
