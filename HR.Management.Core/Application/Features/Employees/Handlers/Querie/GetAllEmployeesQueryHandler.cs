using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HR.Management.Application.DTOs;
using HR.Management.Domain.Entities;
using HR.Management.Application.Features.Employees.Requests.Queries;
using HR.Management.Application.Contracts.Persistence; // Ensure this is the correct namespace

namespace HR.Management.Application.Features.Employees.Handlers.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            // Fetch the employees from the repository
            var employees = await _employeeRepository.GetAllEmployeesAsync(); // Ensure this method returns List<Employee>

            // Optionally, you can map Employee to EmployeeDto here if not using AutoMapper
            var employeeDtos = employees.Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                DateOfBirth = emp.DateOfBirth,
                Gender = emp.Gender,
                EmailAddress = emp.EmailAddress,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.Address,
                DepartmentId = emp.DepartmentId,
                JobTitle = emp.JobTitle,
                ManagerId = emp.ManagerId,
                HireDate = emp.HireDate,
                EmploymentStatus = emp.EmploymentStatus,
                ContractType = emp.ContractType,
                Salary = emp.Salary
            });

            return employeeDtos;
        }
    }
}
