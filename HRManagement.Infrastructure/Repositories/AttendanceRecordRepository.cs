using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Infrastructure.Repositories
{
    public class AttendanceRecordRepository : IAttendanceRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AttendanceRecord>> GetAllAttendanceRecordsAsync()
        {
            return await _context.AttendanceRecords.ToListAsync();
        }

        public async Task<AttendanceRecord> GetAttendanceRecordByIdAsync(int id)
        {
            return await _context.AttendanceRecords.FindAsync(id);
        }

        public async Task AddAttendanceRecordAsync(AttendanceRecord attendanceRecord)
        {
            // Ensure DateTime fields are in UTC and converted if necessary
            attendanceRecord.Date = DateTime.SpecifyKind(attendanceRecord.Date, DateTimeKind.Utc).ToUniversalTime();
            attendanceRecord.CheckInTime = attendanceRecord.CheckInTime.HasValue 
                ? DateTime.SpecifyKind(attendanceRecord.CheckInTime.Value, DateTimeKind.Utc).ToUniversalTime() 
                : (DateTime?)null;
            attendanceRecord.CheckOutTime = attendanceRecord.CheckOutTime.HasValue 
                ? DateTime.SpecifyKind(attendanceRecord.CheckOutTime.Value, DateTimeKind.Utc).ToUniversalTime() 
                : (DateTime?)null;
            attendanceRecord.CreatedDate = DateTime.SpecifyKind(attendanceRecord.CreatedDate, DateTimeKind.Utc).ToUniversalTime();

            await _context.AttendanceRecords.AddAsync(attendanceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceRecordAsync(AttendanceRecord attendanceRecord)
        {
            _context.AttendanceRecords.Update(attendanceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendanceRecordAsync(int id)
        {
            var attendanceRecord = await _context.AttendanceRecords.FindAsync(id);
            if (attendanceRecord != null)
            {
                _context.AttendanceRecords.Remove(attendanceRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}
