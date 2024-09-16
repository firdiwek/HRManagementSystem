using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HR.Management.Application.Contracts.Persistence;
using HR.Management.Infrastructure.Repositories;
using HR.Management.Application.Interfaces;
using HR.Management.Domain.Entities;
using HR.Management.Persistence.Repositories;

namespace HR.Management.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register ApplicationDbContext with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repository services
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAttendanceRecordRepository,AttendanceRecordRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            // Add other infrastructure services here

            return services;
        }
    }
}
