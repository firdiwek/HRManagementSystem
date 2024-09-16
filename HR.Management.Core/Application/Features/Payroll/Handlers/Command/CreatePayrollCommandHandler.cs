using HR.Management.Application.Commands;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class CreatePayrollCommandHandler : IRequestHandler<CreatePayrollCommand, Payroll>
    {
        private readonly IPayrollRepository _payrollRepository;

        public CreatePayrollCommandHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<Payroll> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
        {
            var payroll = new Payroll
            {
                EmployeeId = request.EmployeeId,
                Salary = request.Salary,
                PaymentDate = request.PayDate,
                Comments = request.Comments
            };

            return await _payrollRepository.AddPayrollAsync(payroll);
        }
    }
}
