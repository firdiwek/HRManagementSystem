using MediatR;
using System;

namespace HR.Management.Application.Commands
{
    public class UpdatePayrollCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public DateTime PayDate { get; set; }
        public string? Comments { get; set; }
    }
}
