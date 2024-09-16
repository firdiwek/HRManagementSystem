using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.DTOs;
using HR.Management.Application.Features.Employees.Requests.Queries;
using HR.Management.Domain.Entities;

public class GetEmployeesPagedHandler : IRequestHandler<GetEmployeesPagedQuery, PagedResult<EmployeeDto>>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeesPagedHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<EmployeeDto>> Handle(GetEmployeesPagedQuery request, CancellationToken cancellationToken)
    {
        // Fetch the paged result of employees
        var employees = await _repository.GetPagedEmployeesAsync(request.Page, request.PageSize);

        // Extract the total number of records from the PagedResult<Employee>
        var totalRecords = employees.TotalRecords;  // Get total count, not the whole object

        // Map employees.Items to a list of EmployeeDto
        var employeeDtos = employees.Items.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            EmailAddress = e.EmailAddress,
            DepartmentId = e.DepartmentId
        }).ToList();

        // Return the mapped PagedResult with employeeDtos and totalRecords count
        return new PagedResult<EmployeeDto>
        {
            Items = employeeDtos,
            TotalRecords = totalRecords,  // Total count extracted from PagedResult<Employee>
            CurrentPage = request.Page,
            PageSize = request.PageSize
        };
    }
}
