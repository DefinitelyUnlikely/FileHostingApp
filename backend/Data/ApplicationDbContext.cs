using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Models.Folder> Folders { get; set; }
    public DbSet<Models.File> Files { get; set; }
}