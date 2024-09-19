using Microsoft.AspNetCore.Identity;

namespace HR.Management.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        // Add custom fields if needed
    }
}
