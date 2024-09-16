using HR.Management.Application.Commands;
using HR.Management.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class UpdatePayrollCommandHandler : IRequestHandler<UpdatePayrollCommand, bool>
    {
        private readonly IPayrollRepository _payrollRepository;

        public UpdatePayrollCommandHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<bool> Handle(UpdatePayrollCommand request, CancellationToken cancellationToken)
        {
            var payroll = await _payrollRepository.GetPayrollByIdAsync(request.Id);
            if (payroll == null) return false;

            payroll.EmployeeId = request.EmployeeId;
            payroll.Salary = request.Salary;
            payroll.PaymentDate = request.PayDate;
            payroll.Comments = request.Comments;

            return await _payrollRepository.UpdatePayrollAsync(payroll);
        }
    }
}
