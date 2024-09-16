// HR.Management.Application/Features/AttendanceRecords/Requests/Queries/GetAllAttendanceRecordsQuery.cs
using HR.Management.Application.DTOs;
using HR.Management.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HR.Management.Application.Features.AttendanceRecords.Requests.Queries
{
    public class GetAllAttendanceRecordsQuery : IRequest<List<AttendanceRecord>>
    {
    }
}
