using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveRequests.Requests.Queries;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestsByEmployeeQueryHandler : IRequestHandler<GetLeaveRequestsByEmployeeQuery, IEnumerable<LeaveRequest>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetLeaveRequestsByEmployeeQueryHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<IEnumerable<LeaveRequest>> Handle(GetLeaveRequestsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _leaveRequestRepository.GetLeaveRequestsByEmployeeAsync(request.EmployeeId);
        }
    }
}
