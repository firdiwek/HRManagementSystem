using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HR.Management.Domain.Entities;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace HR.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
         private readonly IEmailSender _emailSender;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailSender emailSender)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "User created successfully" });
        }

        [HttpPost("login")]
       public async Task<IActionResult> Login([FromBody] LoginDto model)
{
    var user = await _userManager.FindByNameAsync(model.Username);

    if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        return Unauthorized();

    var token = GenerateJwtToken(user);  // Generate JWT token
    var refreshToken = GenerateRefreshToken();  // Generate refresh token

    // Store the refresh token in the user's collection
    user.RefreshTokens.Add(new RefreshToken { 
        Token = refreshToken, 
        Expiration = DateTime.UtcNow.AddDays(7) // Set an expiration for the refresh token
    });

    // Save the user entity with the new refresh token in the database
    await _userManager.UpdateAsync(user);

    // Return both JWT token and refresh token to the client
    return Ok(new { Token = token, RefreshToken = refreshToken });
}

       private string GenerateRefreshToken()
{
    var randomNumber = new byte[32];  // 32-byte secure random number
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomNumber);  // Fill the array with random bytes
        return Convert.ToBase64String(randomNumber);  // Convert the random bytes to a Base64 string
    }
}


  [HttpPost("refresh-token")]
public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
{
    var principal = GetPrincipalFromExpiredToken(model.Token);
    var username = principal.Identity?.Name;

    if (username == null)
        return Unauthorized("Invalid token");

    var user = await _userManager.FindByNameAsync(username);

    if (user == null || !user.RefreshTokens.Any(rt => rt.Token == model.RefreshToken))
        return Unauthorized("Invalid refresh token");

    // Generate new JWT
    var newToken = GenerateJwtToken(user);

    // Optionally, generate a new refresh token as well
    var newRefreshToken = GenerateRefreshToken();

    // Update the refresh token in the database if needed
    await SaveRefreshToken(user, newRefreshToken);

    return Ok(new { token = newToken, refreshToken = newRefreshToken });
}

       private async Task SaveRefreshToken(ApplicationUser user, string newRefreshToken)
{
    // Assuming you have a RefreshToken entity and your DbContext is set up correctly

    var existingToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == newRefreshToken);
    
    if (existingToken != null)
    {
        // Optionally, you might want to update the expiration date or other details
        existingToken.Expiration = DateTime.UtcNow.AddDays(30); // Example: Set expiration date
    }
    else
    {
        // Add new refresh token
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            Expiration = DateTime.UtcNow.AddDays(30) // Example: Set expiration date
        });
    }

    // Save changes to the database
    await _userManager.UpdateAsync(user);
}


        private ClaimsPrincipal GetPrincipalFromExpiredToken(string AccessToken)
        {
              var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false, // Here we are saying that we don't care about the token's expiration date
        ValidateIssuerSigningKey = true,
        ValidIssuer = _configuration["JwtSettings:Issuer"],
        ValidAudience = _configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]))
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    SecurityToken securityToken;
    var principal = tokenHandler.ValidateToken(AccessToken, tokenValidationParameters, out securityToken);
    var jwtSecurityToken = securityToken as JwtSecurityToken;

    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        throw new SecurityTokenException("Invalid token");

    return principal;
        }



      [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
            return BadRequest("Invalid email address");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = Url.Action("ResetPassword", "Auth", new { token, email = model.Email }, Request.Scheme);

        await _emailSender.SendEmailAsync(user.Email, "Password Reset", $"Please reset your password using this link: {resetLink}");

        return Ok(new { Message = "Password reset link sent" });
    }




[HttpPost("reset-password")]
public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
{
    var user = await _userManager.FindByEmailAsync(model.Email);

    if (user == null)
        return BadRequest("Invalid email address");

    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

    if (!result.Succeeded)
        return BadRequest(result.Errors);

    return Ok(new { Message = "Password reset successful" });
}


[HttpPost("change-password")]
[Authorize]
public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
{
    var user = await _userManager.GetUserAsync(User);

    if (user == null)
        return Unauthorized();

    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

    if (!result.Succeeded)
        return BadRequest(result.Errors);

    return Ok(new { Message = "Password changed successfully" });
}
[HttpGet("profile")]
[Authorize]
public async Task<IActionResult> GetProfile()
{
    var user = await _userManager.GetUserAsync(User);

    if (user == null)
        return NotFound();

    var profile = new
    {
        user.UserName,
        user.Email
    };

    return Ok(profile);
}
[HttpPost("update-profile")]
[Authorize]
public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto model)
{
    var user = await _userManager.GetUserAsync(User);

    if (user == null)
        return Unauthorized();

    user.Email = model.Email;
    user.UserName = model.Username;

    var result = await _userManager.UpdateAsync(user);

    if (!result.Succeeded)
        return BadRequest(result.Errors);

    return Ok(new { Message = "Profile updated successfully" });
}


[HttpPost("verify-email")]
[Authorize]
public async Task<IActionResult> VerifyEmail()
{
    // Get the currently logged-in user
    var user = await _userManager.GetUserAsync(User);

    if (user == null)
        return Unauthorized();

    // Generate the email confirmation token
    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

    // Create a verification link
    var verificationLink = Url.Action("ConfirmEmail", "Auth", new { token, email = user.Email }, Request.Scheme);

    // Send the verification email
    await SendVerificationEmail(user.Email, verificationLink);

    return Ok(new { Message = "Verification email sent" });
}


       private async Task SendVerificationEmail(string email, string verificationLink)
{
    // Email sending logic (could use SMTP or a third-party service like SendGrid)
    var subject = "Email Verification";
    var message = $"Please verify your email using this link: {verificationLink}";

    // You can use any email sending logic, for example, SMTP or an external service
    await _emailSender.SendEmailAsync(email, subject, message); 
}




        [HttpGet("confirm-email")]
public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
{
    var user = await _userManager.FindByEmailAsync(email);

    if (user == null)
        return BadRequest("Invalid email address");

    var result = await _userManager.ConfirmEmailAsync(user, token);

    if (!result.Succeeded)
        return BadRequest(result.Errors);

    return Ok(new { Message = "Email confirmed successfully" });
}

[HttpPost("assign-role")]
[Authorize(Roles = "Admin")]
public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
{
    var user = await _userManager.FindByNameAsync(model.Username);

    if (user == null)
        return NotFound();

    var result = await _userManager.AddToRoleAsync(user, model.Role);

    if (!result.Succeeded)
        return BadRequest(result.Errors);

    return Ok(new { Message = "Role assigned successfully" });
}










       private string GenerateJwtToken(ApplicationUser user)
{
    var userRoles = _userManager.GetRolesAsync(user).Result; // Fetch user roles

    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    }
    .Union(userRoles.Select(role => new Claim(ClaimTypes.Role, role))); // Add role claims

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _configuration["JwtSettings:Issuer"],
        audience: _configuration["JwtSettings:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
        signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
}

    }

    public class AssignRoleDto
    {
    public string Username { get; set; }=string.Empty;
    public string Role { get; set;} =string.Empty;
    }

    public class UpdateProfileDto
    {
    public string Email { get; set; }=string.Empty;
    public string Username { get; set;}=string.Empty;
    }

    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }=string.Empty;
        public string NewPassword { get; set; }=string.Empty;
    }

    public class ResetPasswordDto
    {
    public string Email { get; set; }=string.Empty;
    public string Token { get; set; }=string.Empty;
    public string NewPassword { get; set; }=string.Empty;
    }

    public class ForgotPasswordDto
    {
        public string Email { get; set; }=string.Empty;

    }

    public class RefreshTokenDto
    {
    public string Token { get; set; }=string.Empty;
    public string RefreshToken { get; set; }=string.Empty;

    }

    public class LoginDto
    {
    public string Username { get; set; }=string.Empty;
    public string Password { get; set; }=string.Empty;
    }

    public class RegisterDto
    {
    public string Username { get; set; }=string.Empty;
    public string Email { get; set; }=string.Empty;
    public string Password { get; set; }=string.Empty;
    }
}
 