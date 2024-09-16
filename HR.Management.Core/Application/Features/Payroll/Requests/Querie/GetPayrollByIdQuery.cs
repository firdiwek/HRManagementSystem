using HR.Management.Domain.Entities;
using MediatR;

namespace HR.Management.Application.Queries
{
    public class GetPayrollByIdQuery : IRequest<Payroll>
    {
        public int Id { get; set; }
    }
}
