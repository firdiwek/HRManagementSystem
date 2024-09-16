using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain;
using HR.Management.Application.Features.Employees.Requests.Commands;

namespace HR.Management.Application.Features.Employees.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing employee from the repository
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (existingEmployee == null) return false; // Employee not found

            // Map the updated data from the command to the existing employee entity
            _mapper.Map(request, existingEmployee);

            // Update the employee in the repository
            var result = await _employeeRepository.UpdateEmployeeAsync(existingEmployee);

            return result; // Return whether the update was successful
        }
    }
}
