using System;

namespace HR.Management.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmploymentStatus { get; set; } = string.Empty;
        public string ContractType { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
