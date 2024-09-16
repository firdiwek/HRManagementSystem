using HR.Management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository
    {
        Task<LeaveType> GetByIdAsync(int id);
        Task<LeaveType> GetLeaveTypeByNameAsync(string name);
        Task<IEnumerable<LeaveType>> GetAllAsync();
        Task AddAsync(LeaveType leaveType);
        Task UpdateAsync(LeaveType leaveType);
        Task DeleteAsync(int id);
    }
}
