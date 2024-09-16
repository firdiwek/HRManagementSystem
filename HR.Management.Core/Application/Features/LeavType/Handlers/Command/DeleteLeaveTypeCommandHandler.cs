using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        await _leaveTypeRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}
