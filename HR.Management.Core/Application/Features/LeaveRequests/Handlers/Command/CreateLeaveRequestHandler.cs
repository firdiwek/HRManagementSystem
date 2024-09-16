// HR.Management.Application/Features/LeaveRequests/Handlers/CreateLeaveRequestHandler.cs
using HR.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.LeaveRequests.Handlers
{
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = request.EmployeeId,
                LeaveType = request.LeaveType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Reason = request.Reason,
                Status = "Pending",
                CreatedDate = DateTime.UtcNow
            };

            await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
