using System;
using System.Collections.Generic;

namespace HR.Management.Domain.Entities
{
    public class LeaveType
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // e.g., Sick Leave, Casual Leave
        public string Description { get; set; } // Details about the leave type
        public int DefaultDays { get; set; } // Default number of days for this leave type
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Defaults to current UTC time
        public DateTime? LastModifiedDate { get; set; } // Nullable for optional updates

        // Leave Requests Relationship
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
