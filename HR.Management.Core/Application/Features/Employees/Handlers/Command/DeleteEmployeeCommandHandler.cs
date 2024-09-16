using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.Employees.Requests.Commands;

namespace HR.Management.Application.Features.Employees.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Call the repository method to delete by ID
            var result = await _employeeRepository.DeleteEmployeeAsync(request.Id);
            return result; // Return whether the deletion was successful
        }
    }
}
