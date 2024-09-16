// HR.Management.Infrastructure/Configuration/LeaveRequestConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR.Management.Domain.Entities;

namespace HR.Management.Infrastructure.Configuration
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.ToTable("LeaveRequests");
            builder.HasKey(lr => lr.Id);

            builder.Property(lr => lr.LeaveType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(lr => lr.StartDate)
                .IsRequired();

            builder.Property(lr => lr.EndDate)
                .IsRequired();

            builder.Property(lr => lr.Reason)
                .HasMaxLength(500);

            builder.Property(lr => lr.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(lr => lr.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
