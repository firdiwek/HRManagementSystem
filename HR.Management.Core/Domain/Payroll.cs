using System;

namespace HR.Management.Domain.Entities
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employee? Employee { get; set; }
        public string? Comments {get;set;}
        
    }
}
