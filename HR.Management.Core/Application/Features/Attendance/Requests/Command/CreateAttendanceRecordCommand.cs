// HR.Management.Application/Features/AttendanceRecords/Requests/Commands/CreateAttendanceRecordCommand.cs
using MediatR;
using System;

namespace HR.Management.Application.Features.AttendanceRecords.Requests.Commands
{
    public class CreateAttendanceRecordCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
