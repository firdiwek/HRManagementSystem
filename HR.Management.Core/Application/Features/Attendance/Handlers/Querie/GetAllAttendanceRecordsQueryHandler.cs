// HR.Management.Application/Features/AttendanceRecords/Handlers/Queries/GetAllAttendanceRecordsQueryHandler.cs
using HR.Management.Application.DTOs;
using HR.Management.Application.Interfaces;
using HR.Management.Application.Features.AttendanceRecords.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Management.Domain.Entities;

namespace HR.Management.Application.Features.AttendanceRecords.Handlers.Queries
{
    public class GetAllAttendanceRecordsQueryHandler : IRequestHandler<GetAllAttendanceRecordsQuery, List<AttendanceRecord>>
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public GetAllAttendanceRecordsQueryHandler(IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        public async Task<List<AttendanceRecord>> Handle(GetAllAttendanceRecordsQuery request, CancellationToken cancellationToken)
        {
            var attendanceRecords = await _attendanceRecordRepository.GetAllAttendanceRecordsAsync();
            return attendanceRecords.Select(ar => new AttendanceRecord
            {
                Id = ar.Id,
                EmployeeId = ar.EmployeeId,
                Date = ar.Date,
                CheckInTime = ar.CheckInTime,
                CheckOutTime = ar.CheckOutTime,
                TotalHours = ar.TotalHours,
                CreatedDate = ar.CreatedDate
            }).ToList();
        }
    }
}
