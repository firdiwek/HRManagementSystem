using AutoMapper;
using HR.Management.Application.Commands;
using HR.Management.Application.DTOs;
using HR.Management.Application.Features.Employees.Requests.Commands;
using HR.Management.Domain;
using HR.Management.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<DeleteEmployeeCommand,Employee>();

        CreateMap<CreateDepartmentCommand, Department>();
        CreateMap<UpdateDepartmentCommand, Department>();
        CreateMap<DeleteDepartmentCommand, Department>();
        
        // Add other mappings here as needed
    }
}
