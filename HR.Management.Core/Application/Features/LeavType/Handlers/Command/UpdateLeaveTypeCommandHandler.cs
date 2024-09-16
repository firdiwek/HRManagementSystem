using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        leaveType.Name = request.Name;
        leaveType.Description = request.Description;
        leaveType.DefaultDays = request.DefaultDays;
        // Update the last modified date or other fields if needed

        await _leaveTypeRepository.UpdateAsync(leaveType);

        return Unit.Value;
    }
}
