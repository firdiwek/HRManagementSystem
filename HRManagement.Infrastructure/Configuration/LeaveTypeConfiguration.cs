using HR.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Management.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            // Table name
            builder.ToTable("LeaveTypes");

            // Primary Key
            builder.HasKey(lt => lt.Id);

            // Properties
            builder.Property(lt => lt.Name)
                .IsRequired()
                .HasMaxLength(100); // Adjust length as needed

            builder.Property(lt => lt.DefaultDays)
                .IsRequired();

            builder.Property(lt => lt.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Set default value to current timestamp

    

            // Relationships
            // If there are any relationships, configure them here
        }
    }
}
