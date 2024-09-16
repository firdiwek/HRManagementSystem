using HR.Management.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Replace with your actual PostgreSQL connection string
        optionsBuilder.UseNpgsql("Host=localhost;Database=HRSystem;Username=postgres;Password=Frdu@1234;Port=5433");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
