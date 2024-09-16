using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveTypes.Requests.Queries;
using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, IEnumerable<LeaveType>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetAllLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<IEnumerable<LeaveType>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        return await _leaveTypeRepository.GetAllAsync();
    }
}
