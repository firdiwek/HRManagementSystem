// HR.Management.Application/Features/AttendanceRecords/Handlers/Commands/UpdateAttendanceRecordCommandHandler.cs
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.AttendanceRecords.Requests.Commands;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Management.Application.Features.AttendanceRecords.Handlers.Commands
{
    public class UpdateAttendanceRecordCommandHandler : IRequestHandler<UpdateAttendanceRecordCommand>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public UpdateAttendanceRecordCommandHandler(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<Unit> Handle(UpdateAttendanceRecordCommand request, CancellationToken cancellationToken)
        {
            var attendanceRecord = await _attendanceRecordRepository.GetAttendanceRecordByIdAsync(request.Id);

            if (attendanceRecord == null)
            {
                throw new NotFoundException(nameof(AttendanceRecord), request.Id);
            }

            attendanceRecord.EmployeeId = request.EmployeeId;
            attendanceRecord.Date = request.Date;
            attendanceRecord.CheckInTime = request.CheckInTime;
            attendanceRecord.CheckOutTime = request.CheckOutTime;
            attendanceRecord.TotalHours = request.TotalHours;
            attendanceRecord.CreatedDate = request.CreatedDate;

            await _attendanceRecordRepository.UpdateAttendanceRecordAsync(attendanceRecord);
            return Unit.Value;
        }
    }
}
