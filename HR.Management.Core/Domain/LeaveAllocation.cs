using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HR.Management.Core.Domain
{

    public class LeaveAllocation
    {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public int DaysAllocated { get; set; }
    public DateTime AllocationDate { get; set; }
    public int DaysRemaining { get; set; }
    }
}