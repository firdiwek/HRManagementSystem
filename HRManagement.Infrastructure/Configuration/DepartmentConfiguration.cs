using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR.Management.Domain.Entities;

namespace HR.Management.Infrastructure.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table name configuration
            builder.ToTable("Departments");

            // Primary key configuration
            builder.HasKey(d => d.DepartmentId);

            // Property configurations
            builder.Property(d => d.Name)
                .HasMaxLength(100); // Name is optional, no IsRequired() method used.

            builder.Property(d => d.CreatedDate)
                .IsRequired() // CreatedDate is required
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Default value for CreatedDate

            builder.Property(d => d.Description)
                .HasMaxLength(500); // Description is optional

            // Relationships configuration
            // A department can have many employees
            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department) // One Department has many Employees
                .HasForeignKey(e => e.DepartmentId) // FK in Employee table
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete for related employees
        }
    }
}
