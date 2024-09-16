// HR.Management.Domain/Entities/LeaveRequest.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Management.Domain.Entities
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; } // Foreign key to Employee

        [Required]
        public string? LeaveType { get; set; } // E.g., Annual, Sick, etc.

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string? Reason { get; set; } // Optional reason for leave

        public string? Status { get; set; } // E.g., Pending, Approved, Rejected

        public DateTime CreatedDate { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
    }
}
