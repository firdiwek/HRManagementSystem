using HR.Management.Application.Queries;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Handlers
{
    public class GetPayrollByIdQueryHandler : IRequestHandler<GetPayrollByIdQuery, Payroll>
    {
        private readonly IPayrollRepository _payrollRepository;

        public GetPayrollByIdQueryHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<Payroll> Handle(GetPayrollByIdQuery request, CancellationToken cancellationToken)
        {
            return await _payrollRepository.GetPayrollByIdAsync(request.Id);
        }
    }
}
