using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.DTOs;
using MediatR;

namespace HR.Management.Core.Application.Features.Employees.Handlers.Querie
{
    public class GetEmployeesByDepartmentHandler : IRequestHandler<GetEmployeesByDepartmentQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeesByDepartmentHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetEmployeesByDepartementAsync(request.DepartmentId);
            return employees.Select(e => new EmployeeDto
            {
                // Mapping logic here...
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            EmailAddress = e.EmailAddress,
            DepartmentId = e.DepartmentId,
            // DepartmentName = e.Department.Name
            }).ToList();
        }
    }
}