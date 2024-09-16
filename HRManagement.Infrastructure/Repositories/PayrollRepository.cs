using HR.Management.Application.Contracts.Persistence;
using HR.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Management.Infrastructure.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _context;

        public PayrollRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Payroll> AddPayrollAsync(Payroll payroll)
{
    var result = await _context.Payrolls.AddAsync(payroll);
    await _context.SaveChangesAsync();
    return result.Entity;
}


       

        public async Task<bool> UpdatePayrollAsync(Payroll payroll)
        {
            try
            {
                _context.Payrolls.Update(payroll);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                // Handle exceptions as needed
                return false;
            }
        }

        public async Task<bool> DeletePayrollByIdAsync(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll != null)
            {
                _context.Payrolls.Remove(payroll);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Payroll?> GetPayrollByIdAsync(int id)
        {
            return await _context.Payrolls
                .Include(p => p.Employee) // Ensure the Employee is included if needed
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync()
        {
            return await _context.Payrolls
                .Include(p => p.Employee) // Ensure Employees are included if needed
                .ToListAsync();
        }

       
    }
}
