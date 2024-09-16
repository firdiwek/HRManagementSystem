using HR.Management.Application.DTOs;
using MediatR;

public class GetEmployeesByDepartmentQuery : IRequest<List<EmployeeDto>>
{
    public int DepartmentId { get; set; }
}