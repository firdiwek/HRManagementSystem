// HR.Management.Application/Features/AttendanceRecords/Handlers/Commands/DeleteAttendanceRecordCommandHandler.cs
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.AttendanceRecords.Requests.Commands;
using HR.Management.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.AttendanceRecords.Handlers.Commands
{
    public class DeleteAttendanceRecordCommandHandler : IRequestHandler<DeleteAttendanceRecordCommand>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public DeleteAttendanceRecordCommandHandler(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<Unit> Handle(DeleteAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var attendanceRecord = await _attendanceRecordRepository.GetAttendanceRecordByIdAsync(request.Id);
            if (attendanceRecord == null)
            {
                throw new NotFoundException(nameof(AttendanceRecords), request.Id);
            }

            await _attendanceRecordRepository.DeleteAttendanceRecordAsync(request.Id);
            return Unit.Value;
        }
    }
}
