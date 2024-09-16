using System.Collections.Generic;
using MediatR;
using HR.Management.Application.DTOs;

namespace HR.Management.Application.Features.Employees.Requests.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
