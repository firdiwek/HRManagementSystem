// HR.Management.Application/Features/AttendanceRecords/Requests/Queries/GetAttendanceRecordByIdQuery.cs
using HR.Management.Domain.Entities;
using MediatR;

namespace HR.Management.Application.Features.AttendanceRecords.Requests.Queries
{
    public class GetAttendanceRecordByIdQuery : IRequest<AttendanceRecord>
    {
        public int Id { get; set; }
    }
}
