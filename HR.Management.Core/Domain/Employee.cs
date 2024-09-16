using System;
using System.Collections.Generic;

namespace HR.Management.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentStatus { get; set; }
        public string ContractType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow; // Defaults to current UTC time
        public decimal Salary { get; set; }

        // Foreign Key - Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation property

        // Foreign Key - Manager (Self-Referencing)
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; } // Navigation property
        public ICollection<Employee> Subordinates { get; set; } // Employees under this manager

        // Payroll Relationship
        public ICollection<Payroll> Payrolls { get; set; }

        // Leave Requests Relationship
        public ICollection<LeaveRequest> LeaveRequests { get; set; }

        // Attendance Relationship
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

        // Other possible relationships can be added here, such as performance reviews, promotions, etc.

        // Constructors, methods, and domain-specific logic can be included here as well
    }
}
