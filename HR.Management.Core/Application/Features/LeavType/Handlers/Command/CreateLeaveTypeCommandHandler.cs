using HR.Management.Application.Contracts.Persistence;
using HR.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Management.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = new LeaveType
        {
            Name = request.Name,
            Description = request.Description,
            DefaultDays = request.DefaultDays,
            CreatedDate = DateTime.UtcNow
        };

        await _leaveTypeRepository.AddAsync(leaveType);

        return leaveType.Id;
    }
}
