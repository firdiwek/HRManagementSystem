using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HR.Management.Application.Features.Employees.Requests.Commands;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using HR.Management.Application.Commands;

namespace HR.Management.Application.Features.Employees.Handlers.Commands
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Map CreateDepartmentCommand to Department entity
            var department = _mapper.Map<Department>(request);

            // Add the department to the repository
            var createdDepartment = await _departmentRepository.AddDepartmentAsync(department);

            // Return the newly created department's ID
            return createdDepartment.DepartmentId;
        }
    }
}
