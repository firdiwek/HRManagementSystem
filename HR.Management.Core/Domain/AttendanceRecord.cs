namespace HR.Management.Domain.Entities
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }  // Foreign key to Employee
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public Employee Employee { get; set; }
    }
}
