using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveRequests.Requests.Queries; // Ensure this is added
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.LeaveRequests.Handlers.Query
{
    public class GetAllLeaveRequestsQueryHandler : IRequestHandler<GetAllLeaveRequestsQuery, IEnumerable<LeaveRequest>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetAllLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<IEnumerable<LeaveRequest>> Handle(GetAllLeaveRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _leaveRequestRepository.GetAllLeaveRequestsAsync();
        }
    }
}
