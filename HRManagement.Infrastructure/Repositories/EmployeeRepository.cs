using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain.Entities;

namespace HR.Management.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Ensure that the department exists before adding the employee
            var departmentExists = await _context.Departments
                .AnyAsync(d => d.DepartmentId == employee.DepartmentId);

            if (!departmentExists)
            {
                throw new InvalidOperationException("The specified department does not exist.");
            }

            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., logging)
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByManagerIdAsync(int? managerId)
        {
            return await _context.Employees
                .Where(e => e.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartementAsync(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByName(string name)
        {
            return await _context.Employees
                .Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name))
                .ToListAsync();
        }

       public async Task<PagedResult<Employee>> GetPagedEmployeesAsync(int page, int pageSize)
{
    var totalRecords = await _context.Employees.CountAsync();
    
    var employees = await _context.Employees
        .OrderBy(e => e.Id) // You may want to order by a specific field
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return new PagedResult<Employee>
    {
        Items = employees,
        TotalRecords = totalRecords,
        CurrentPage = page,
        PageSize = pageSize
    };
}


        public async Task<PagedResult<Employee>> GetTotalEmployeesCountAsync()
        {
            var query = _context.Employees.AsQueryable();

            var result = new PagedResult<Employee>
            {
                TotalRecords = await query.CountAsync()
            };

            return result;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
