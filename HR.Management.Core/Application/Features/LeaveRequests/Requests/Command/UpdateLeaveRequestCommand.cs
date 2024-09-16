using MediatR;

namespace HR.Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
        public string? Status { get; set; } // E.g., Approved, Rejected
    }
}