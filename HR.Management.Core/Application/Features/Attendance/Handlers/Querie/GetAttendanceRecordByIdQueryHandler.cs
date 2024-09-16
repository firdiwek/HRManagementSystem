// HR.Management.Application/Features/AttendanceRecords/Handlers/Queries/GetAttendanceRecordByIdQueryHandler.cs
using HR.Management.Application.DTOs;
using HR.Management.Application.Interfaces;
using HR.Management.Application.Features.AttendanceRecords.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.AttendanceRecords.Handlers.Queries
{
    public class GetAttendanceRecordByIdQueryHandler : IRequestHandler<GetAttendanceRecordByIdQuery, AttendanceRecord>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public GetAttendanceRecordByIdQueryHandler(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<AttendanceRecord> Handle(GetAttendanceRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var attendanceRecord = await _attendanceRecordRepository.GetAttendanceRecordByIdAsync(request.Id);
            if (attendanceRecord == null)
            {
                return null;
            }

            return new AttendanceRecord
            {
                Id = attendanceRecord.Id,
                EmployeeId = attendanceRecord.EmployeeId,
                Date = attendanceRecord.Date,
                CheckInTime = attendanceRecord.CheckInTime,
                CheckOutTime = attendanceRecord.CheckOutTime,
                TotalHours = attendanceRecord.TotalHours,
                CreatedDate = attendanceRecord.CreatedDate
            };
        }
    }
}
