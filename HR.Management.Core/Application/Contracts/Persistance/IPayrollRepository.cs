using HR.Management.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Application.Contracts.Persistence
{
    public interface IPayrollRepository
    {
        // Task<Payroll> AddPayrollAsync(Payroll payroll); // Returns ID of the newly created Payroll
        Task<Payroll> AddPayrollAsync(Payroll payroll);

        Task<bool> UpdatePayrollAsync(Payroll payroll);
        Task<bool> DeletePayrollByIdAsync(int id);
        Task<Payroll> GetPayrollByIdAsync(int id);
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync();
    }
}
