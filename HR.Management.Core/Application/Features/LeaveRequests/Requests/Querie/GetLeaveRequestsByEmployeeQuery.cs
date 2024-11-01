using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HR.Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestsByEmployeeQuery : IRequest<IEnumerable<LeaveRequest>>
    {
        public int EmployeeId { get; set; }
    }
}
