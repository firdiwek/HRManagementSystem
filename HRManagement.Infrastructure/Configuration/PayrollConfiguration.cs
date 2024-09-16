using HR.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Management.Infrastructure.Configuration
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            // Table name
            builder.ToTable("Payrolls");

            // Primary key
            builder.HasKey(p => p.Id);

            // Column configurations
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnType("integer");

            builder.Property(p => p.EmployeeId)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(p => p.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PaymentDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");

            builder.Property(p => p.Comments)
                .HasColumnType("text");

            // Relationships
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Or use Cascade if required
        }
    }
}
