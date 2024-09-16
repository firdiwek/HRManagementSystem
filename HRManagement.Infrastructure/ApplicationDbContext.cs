using Microsoft.EntityFrameworkCore;
using HR.Management.Domain;
using HR.Management.Infrastructure.Configuration;
using HR.Management.Domain.Entities;
using HR.Management.Persistence.Configurations;

namespace HR.Management.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments{get; set;}
        public DbSet<LeaveType> LeaveTypes{get; set;}
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }   
        public DbSet<Payroll> Payrolls {get;set;}
        
        // Add DbSets for other entities as needed, e.g., 
        // public DbSet<Department> Departments { get; set; }

        // Configure the model relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


      modelBuilder.Entity<AttendanceRecord>(entity =>
    {
        entity.Property(e => e.Date)
            .HasColumnType("timestamptz"); // Ensures PostgreSQL uses timestamp with time zone

        entity.Property(e => e.CheckInTime)
            .HasColumnType("timestamptz");

        entity.Property(e => e.CheckOutTime)
            .HasColumnType("timestamptz");

        entity.Property(e => e.CreatedDate)
            .HasColumnType("timestamptz");

        entity.Property(e => e.TotalHours)
            .HasColumnType("interval"); // If using interval for TotalHours
    });




            // / Configure Employee-Department relationship
            modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId); // Configure the delete behavior as needed

            modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceRecordConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration()); // Ensure this configuration is applied
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration()); //
            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());

            base.OnModelCreating(modelBuilder);
            // Apply configurations
            // Apply other configurations as needed, e.g.,
            // modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseNpgsql("YourConnectionStringHere");
        //     }
        // }
    }
}

