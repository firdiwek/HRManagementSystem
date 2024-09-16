

// namespace HR.Management.Application.Features.Employees.Handlers.Queries
// {
//     public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
//     {
//         private readonly IEmployeeRepository _employeeRepository;

//         public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
//         {
//             _employeeRepository = employeeRepository;
//         }

//         public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
//         {
//             var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
//             if (employee == null) return null; // Handle as needed

//             // Map domain entity to DTO (you can use a library like AutoMapper here)
//             return new EmployeeDto
//             {
//                 Id = employee.Id,
//                 FirstName = employee.FirstName,
//                 LastName = employee.LastName,
//                 DateOfBirth = employee.DateOfBirth,
//                 Gender = employee.Gender,
//                 EmailAddress = employee.EmailAddress,
//                 PhoneNumber = employee.PhoneNumber,
//                 Address = employee.Address,
//                 DepartmentId = employee.DepartmentId,
//                 JobTitle = employee.JobTitle,
//                 ManagerId = employee.ManagerId,
//                 HireDate = employee.HireDate,
//                 EmploymentStatus = employee.EmploymentStatus,
//                 ContractType = employee.ContractType,
//                 Salary = employee.Salary
//             };
//         }
//     }
// }
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.DTOs;
using HR.Management.Application.Features.Employees.Requests.Queries;

namespace HR.Management.Application.Features.Employees.Handlers.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null) 
            return null; // Handle as needed

            // Map domain entity to DTO using AutoMapper
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
