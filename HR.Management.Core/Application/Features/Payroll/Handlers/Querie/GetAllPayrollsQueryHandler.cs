using HR.Management.Application.Queries;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain.Entities;
using MediatR;


namespace HR.Management.Application.Handlers
{
    public class GetAllPayrollsQueryHandler : IRequestHandler<GetAllPayrollsQuery, IEnumerable<Payroll>>
    {
        private readonly IPayrollRepository _payrollRepository;

        public GetAllPayrollsQueryHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<IEnumerable<Payroll>> Handle(GetAllPayrollsQuery request, CancellationToken cancellationToken)
        {
            return await _payrollRepository.GetAllPayrollsAsync();
        }
    }
}
