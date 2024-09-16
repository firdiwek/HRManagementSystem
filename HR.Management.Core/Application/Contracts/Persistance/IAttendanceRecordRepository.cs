// HR.Management.Application/Interfaces/IAttendanceRecordRepository.cs
using HR.Management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Application.Interfaces
{
    public interface IAttendanceRecordRepository
    {
        Task<IEnumerable<AttendanceRecord>> GetAllAttendanceRecordsAsync();
        Task<AttendanceRecord> GetAttendanceRecordByIdAsync(int id);
        Task AddAttendanceRecordAsync(AttendanceRecord attendanceRecord);
        Task UpdateAttendanceRecordAsync(AttendanceRecord attendanceRecord);
        Task DeleteAttendanceRecordAsync(int id);
    }
}
