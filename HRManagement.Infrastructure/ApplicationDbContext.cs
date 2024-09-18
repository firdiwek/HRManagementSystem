using HR.Management.Domain.Entities;
using HR.Management.Infrastructure.Configuration;
using HR.Management.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets for your entities
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }

    // Configure the model relationships and constraints
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Your existing configurations
        modelBuilder.Entity<AttendanceRecord>(entity =>
        {
            entity.Property(e => e.Date)
                .HasColumnType("timestamptz");

            entity.Property(e => e.CheckInTime)
                .HasColumnType("timestamptz");

            entity.Property(e => e.CheckOutTime)
                .HasColumnType("timestamptz");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamptz");

            entity.Property(e => e.TotalHours)
                .HasColumnType("interval");
        });

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId);

        modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
        modelBuilder.ApplyConfiguration(new AttendanceRecordConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
    }
}
