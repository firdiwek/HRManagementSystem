// HR.Management.Application/Features/LeaveRequests/Handlers/UpdateLeaveRequestHandler.cs
using HR.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Management.Application.Interfaces;
using MediatR;
using HR.Management.Application.Exceptions;

using System.Threading;
using System.Threading.Tasks;

using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.LeaveRequests.Handlers
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            leaveRequest.Status = request.Status;
            await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);

            return Unit.Value;
        }
    }
}
