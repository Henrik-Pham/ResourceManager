namespace ResourceManager.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public List<string> Roles { get; set; } = new();
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public int FailedLoginAttempts { get; set; } = 0;
    public bool IsLocked { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
}