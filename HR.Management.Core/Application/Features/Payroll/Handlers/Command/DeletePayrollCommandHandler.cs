using HR.Management.Application.Commands;
using HR.Management.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class DeletePayrollCommandHandler : IRequestHandler<DeletePayrollCommand, bool>
    {
        private readonly IPayrollRepository _payrollRepository;

        public DeletePayrollCommandHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<bool> Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
        {
            return await _payrollRepository.DeletePayrollByIdAsync(request.Id);
        }
    }
}
