using Microsoft.EntityFrameworkCore;
using ResourceManager.Models;

namespace ResourceManager.DTO;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users => Set<User>();
    public DbSet<FileResource> FileResources => Set<FileResource>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<SharedFile> SharedFiles => Set<SharedFile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Username).IsUnique();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.Email).IsUnique();

            // One to many relation: User -> FileResources
            entity.HasMany(e => e.FileResources)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<FileResource>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FileName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.StoragePath).IsRequired();
            entity.Property(e => e.ContentType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FileHash).HasMaxLength(64);
            entity.HasIndex(e => e.FileHash);

            // Many to many relation via SharedFiles
            entity.HasMany(e => e.SharedWith)
                .WithOne(e => e.FileResource)
                .HasForeignKey(e => e.FileResourceId);
        });
}