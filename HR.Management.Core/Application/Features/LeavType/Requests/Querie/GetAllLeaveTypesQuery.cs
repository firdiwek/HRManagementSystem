using MediatR;
using System.Collections.Generic;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetAllLeaveTypesQuery : IRequest<IEnumerable<LeaveType>>
    {
    }
}
