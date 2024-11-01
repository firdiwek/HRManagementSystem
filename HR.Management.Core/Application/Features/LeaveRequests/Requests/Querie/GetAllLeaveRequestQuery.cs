using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HR.Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetAllLeaveRequestsQuery : IRequest<IEnumerable<LeaveRequest>>
    {
        // You can add additional filters here if needed, for example:
        // public int? EmployeeId { get; set; }
    }
}
