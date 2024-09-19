public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }=string.Empty;
    public DateTime Expiration { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expiration;
    public bool IsRevoked { get; set; }
    public bool IsActive => !IsExpired && !IsRevoked;
}
