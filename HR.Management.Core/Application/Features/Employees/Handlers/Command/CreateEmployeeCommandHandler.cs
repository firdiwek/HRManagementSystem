// using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain;
using HR.Management.Application.Features.Employees.Requests.Commands;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.Employees.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Map CreateEmployeeCommand to Employee entity
            var employee = _mapper.Map<Employee>(request);

            // Add the employee to the repository
            var result = await _employeeRepository.AddEmployeeAsync(employee);

            return result.Id; // Return the newly created employee's ID
        }
    }
}
