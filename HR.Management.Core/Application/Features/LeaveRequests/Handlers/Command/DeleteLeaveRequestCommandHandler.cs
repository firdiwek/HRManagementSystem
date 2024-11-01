using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveRequests.Requests.Commands; // Ensure this is added
using HR.Management.Application.Interfaces;
using HR.Management.Core.Application.Features.LeaveRequests.Requests.Command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.LeaveRequests.Handlers.Command
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            await _leaveRequestRepository.DeleteLeaveRequestAsync(request.Id);
            return Unit.Value;
        }
    }
}
