using HR.Management.Application.DTOs;
using MediatR;

public class SearchEmployeesByNameQuery : IRequest<List<EmployeeDto>>
{
    public string Name { get; set; }
}