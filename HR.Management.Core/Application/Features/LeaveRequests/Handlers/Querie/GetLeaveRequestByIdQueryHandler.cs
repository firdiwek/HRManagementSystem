using HR.Management.Application.Features.LeaveRequests.Requests.Queries;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;

public class GetLeaveRequestByIdQueryHandler : IRequestHandler<GetLeaveRequestByIdQuery, LeaveRequest>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestByIdQueryHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<LeaveRequest> Handle(GetLeaveRequestByIdQuery request, CancellationToken cancellationToken)
    {
        return await _leaveRequestRepository.GetLeaveRequestByIdAsync(request.Id);
    }
}
