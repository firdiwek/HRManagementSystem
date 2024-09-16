using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR.Management.Domain.Entities;

namespace HR.Management.Infrastructure.Configuration
{
    public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
            builder.ToTable("AttendanceRecords");
            builder.HasKey(ar => ar.Id);

            // Configure columns with appropriate types
            builder.Property(ar => ar.Date)
                .IsRequired()
                .HasColumnType("timestamptz"); // timestamp with time zone

            builder.Property(ar => ar.CheckInTime)
                .HasColumnType("timestamptz"); // timestamp with time zone

            builder.Property(ar => ar.CheckOutTime)
                .HasColumnType("timestamptz"); // timestamp with time zone

            builder.Property(ar => ar.TotalHours)
                .HasColumnType("interval");

            builder.Property(ar => ar.CreatedDate)
                .HasColumnType("timestamptz") // timestamp with time zone
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(ar => ar.Employee)
                .WithMany(e => e.AttendanceRecords)
                .HasForeignKey(ar => ar.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
