using HR.Management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Application.Interfaces
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest> GetLeaveRequestByIdAsync(int id);
        Task AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task DeleteLeaveRequestAsync(int id);

        // Non-async method
        LeaveRequest GetLeaveRequestById(int id);
    }
}
