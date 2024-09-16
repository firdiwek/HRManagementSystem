using HR.Management.Application.Commands;
using HR.Management.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _departmentRepository.DeleteDepartmentAsync(request.Id);
            return Unit.Value;
        }
    }
}