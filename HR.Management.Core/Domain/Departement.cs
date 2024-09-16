using HR.Management.Domain.Entities;

public class Department
{
    public int DepartmentId { get; set; } // Primary Key
    required
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Defaults to current UTC time
    public ICollection<Employee>? Employees { get; set; } // Navigation property
}
