using HR.Management.Application.Features.AttendanceRecords.Requests.Commands;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using MediatR;

public class CreateAttendanceRecordCommandHandler : IRequestHandler<CreateAttendanceRecordCommand, int>
{
    private readonly IAttendanceRecordRepository _attendanceRecordRepository;

    public CreateAttendanceRecordCommandHandler(IAttendanceRecordRepository attendanceRecordRepository)
    {
        _attendanceRecordRepository = attendanceRecordRepository;
    }

    public async Task<int> Handle(CreateAttendanceRecordCommand request, CancellationToken cancellationToken)
    {
        var attendanceRecord = new AttendanceRecord
        {
            EmployeeId = request.EmployeeId,
            Date = request.Date.ToUniversalTime(),  // Convert DateTime to UTC
            CheckInTime = request.CheckInTime?.ToUniversalTime(),  // Convert nullable DateTime to UTC
            CheckOutTime = request.CheckOutTime?.ToUniversalTime(),  // Convert nullable DateTime to UTC
            TotalHours = request.TotalHours,
            CreatedDate = request.CreatedDate.ToUniversalTime()  // Convert DateTime to UTC
        };

        await _attendanceRecordRepository.AddAttendanceRecordAsync(attendanceRecord);
        return attendanceRecord.Id;
    }
}
