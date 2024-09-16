using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.DTOs;

public class SearchEmployeesByNameHandler : IRequestHandler<SearchEmployeesByNameQuery, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _repository;

    public SearchEmployeesByNameHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeDto>> Handle(SearchEmployeesByNameQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repository.GetEmployeesByName(request.Name);
        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            EmailAddress = e.EmailAddress,
            DepartmentId = e.DepartmentId
        }).ToList();
    }
}
