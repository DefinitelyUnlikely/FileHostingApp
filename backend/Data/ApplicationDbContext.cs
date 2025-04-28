using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Folder> Folders { get; set; }
    public DbSet<FileMeta> Files { get; set; }
    public DbSet<FileData> FilesData { get; set; }
}