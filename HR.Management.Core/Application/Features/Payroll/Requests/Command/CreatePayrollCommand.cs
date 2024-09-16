using HR.Management.Domain.Entities;
using MediatR;
using System;

namespace HR.Management.Application.Commands
{
    public class CreatePayrollCommand : IRequest<Payroll>
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public DateTime PayDate { get; set; }
        public string? Comments { get; set; }
    }
}
