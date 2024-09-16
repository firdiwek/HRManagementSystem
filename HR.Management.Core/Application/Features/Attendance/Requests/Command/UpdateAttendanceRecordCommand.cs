// HR.Management.Application/Features/AttendanceRecords/Requests/Commands/UpdateAttendanceRecordCommand.cs
using MediatR;
using System;

namespace HR.Management.Application.Features.AttendanceRecords.Requests.Commands
{
    public class UpdateAttendanceRecordCommand : IRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
