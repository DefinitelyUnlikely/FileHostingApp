using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class File
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Extension { get; set; }

    public required byte[] FileData { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    public Guid? FolderId { get; set; }
    public Folder? Folder { get; set; }

    public required string UserId { get; set; }
    public required IdentityUser User { get; set; }

}