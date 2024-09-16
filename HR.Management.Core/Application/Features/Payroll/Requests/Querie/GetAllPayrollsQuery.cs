using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HR.Management.Application.Queries
{
    public class GetAllPayrollsQuery : IRequest<IEnumerable<Payroll>>
    {
    }
}
