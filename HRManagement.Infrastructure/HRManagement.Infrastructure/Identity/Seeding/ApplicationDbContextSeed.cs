using HR.Management.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationDbContextSeed
{
    public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Seed roles
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("HR"))
        {
            await roleManager.CreateAsync(new IdentityRole("HR"));
        }

        // Seed default admin user
        var adminUser = await userManager.FindByEmailAsync("frdusisay@gmail.com");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser { UserName = "Firdiwek", Email = "frdusisay@gmail.com" };
            await userManager.CreateAsync(adminUser, "Frdu@1234");

            // Assign the Admin role to the user
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Seed default HR user
        var hrUser = await userManager.FindByEmailAsync("smilex396@gmail.com");
        if (hrUser == null)
        {
            hrUser = new ApplicationUser { UserName = "Hassen", Email = "smilex396@gmail.com" };
            await userManager.CreateAsync(hrUser, "Hr@1234");

            // Assign the HR role to the user
            await userManager.AddToRoleAsync(hrUser, "HR");
        }
    }
}
