using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveTypes.Requests.Queries;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetLeaveTypeByNameQueryHandler : IRequestHandler<GetLeaveTypeByNameQuery, LeaveType>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeByNameQueryHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveType> Handle(GetLeaveTypeByNameQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetLeaveTypeByNameAsync(request.Name);

        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Name);
        }

        return leaveType;
    }
}
