using System;
using MediatR;
using HR.Management.Application.DTOs;

namespace HR.Management.Application.Features.Employees.Requests.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
}
