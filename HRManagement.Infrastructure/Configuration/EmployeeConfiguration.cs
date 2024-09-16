using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HR.Management.Domain;
using HR.Management.Domain.Entities;

namespace HR.Management.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table name configuration
            builder.ToTable("Employees");

            // Primary key configuration
            builder.HasKey(e => e.Id);

            // Property configurations
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.DateOfBirth)
                .IsRequired();

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15);

            builder.Property(e => e.Address)
                .HasMaxLength(255);

            builder.Property(e => e.DepartmentId)
                .IsRequired();

            builder.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ManagerId)
                .IsRequired(false);

            builder.Property(e => e.HireDate)
                .IsRequired();

            builder.Property(e => e.EmploymentStatus)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.ContractType)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relationships configuration (if any)
            // Example: If Employee has a relationship with Department
            // builder.HasOne(e => e.Department)
            //     .WithMany(d => d.Employees)
            //     .HasForeignKey(e => e.DepartmentId);
            
            // Example: If Employee has a relationship with Manager (Self-referencing)
            // builder.HasOne(e => e.Manager)
            //     .WithMany()
            //     .HasForeignKey(e => e.ManagerId)
            //     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
