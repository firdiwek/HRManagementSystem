using HR.Management.Application.DTOs;
using MediatR;

public class GetEmployeesPagedQuery : IRequest<PagedResult<EmployeeDto>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}