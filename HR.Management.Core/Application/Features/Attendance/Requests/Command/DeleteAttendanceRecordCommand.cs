// HR.Management.Application/Features/AttendanceRecords/Requests/Commands/DeleteAttendanceRecordCommand.cs
using MediatR;

namespace HR.Management.Application.Features.AttendanceRecords.Requests.Commands
{
    public class DeleteAttendanceRecordCommand : IRequest
    {
        public int Id { get; set; }
    }
}
