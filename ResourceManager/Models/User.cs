namespace ResourceManager.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public List<string> Roles { get; set; } = new();
    
    // Account status
    public bool IsEmailVerified { get; set; } = false;
    public string? EmailVerificationToken { get; set; }
    public DateTime? EmailVerificationTokenExpires { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    
    // OAuth
    public string? GoogleId { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public bool IsOAuthUser { get; set; } = false;
    
    // Security
    public int FailedLoginAttempts { get; set; } = 0;
    public bool IsLocked { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
    
    // Storage quota (for fremtidig bruk)
    public long StorageQuotaInBytes { get; set; } = 1_073_741_824; // 1GB default
    public long UsedStorageInBytes { get; set; } = 0;
    
    // Relasjoner
    public List<FileResource> FileResources { get; set; } = new();
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}