// HR.Management.Application/Features/LeaveRequests/Requests/Queries/GetLeaveRequestByIdQuery.cs
using HR.Management.Domain.Entities;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestByIdQuery : IRequest<LeaveRequest>
    {
        public int Id { get; set; }
    }
}
