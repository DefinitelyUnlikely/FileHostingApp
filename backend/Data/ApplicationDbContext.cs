using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Folder> Folders { get; set; }
    public DbSet<FileMeta> Files { get; set; }
    public DbSet<FileData> FilesData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Folder 
        modelBuilder.Entity<Folder>()
                    .Property(f => f.ParentFolderIdProxy)
                    .HasComputedColumnSql("COALESCE(\"ParentFolderId\", '00000000-0000-0000-0000-000000000000'::uuid)", stored: true);

        modelBuilder.Entity<Folder>()
                    .HasIndex(f => new { f.Name, f.ParentFolderIdProxy, f.UserId })
                    .IsUnique();

        // File
        modelBuilder.Entity<FileMeta>()
                    .Property(f => f.FolderIdProxy)
                    .HasComputedColumnSql("COALESCE(\"FolderId\", '00000000-0000-0000-0000-000000000000'::uuid)", stored: true);

        modelBuilder.Entity<FileMeta>()
                    .HasIndex(f => new { f.Name, f.Extension, f.FolderIdProxy, f.UserId })
                    .IsUnique();


    }
}