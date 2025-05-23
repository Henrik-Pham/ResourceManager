namespace ResourceManager.Models;

public class FileResource
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string OriginalFileName { get; set; } = string.Empty;
    public string StoragePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSizeInBytes { get; set; }
    public string? FileHash { get; set; } // SHA-256 for duplicate detection
    public string? ThumbnailPath { get; set; }
    
    // Metadata 
    public DateTime UploadedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public bool IsDeleted { get; set; } = false; // Soft delete
    public DateTime? DeletedAt { get; set; }
    
    // File version
    public int Version { get; set; } = 1;
    public Guid? ParentFileId { get; set; } // Referance to previous file version
    
    // Relations
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = null!;
    
    // Sharing
    public List<SharedFile> SharedWith { get; set; } = new();
    
    // Tags for organising
    public List<string> Tags { get; set; } = new();
}