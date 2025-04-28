using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

// We might separarte FileData into its own model.
public class File
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Extension { get; set; }

    public required byte[] FileData { get; set; }

    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? FolderId { get; set; }
    public Folder? Folder { get; set; }

    public required string UserId { get; set; }
    public IdentityUser? User { get; set; }

    // For EF
    public File()
    {
    }

    // For creating new Files
    public File(string name, string extension, byte[] data, string userId, string? folderId = null)
    {

        Id = Guid.NewGuid().ToString();
        Name = name;
        Extension = extension;
        FileData = data;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;

        UserId = userId;
        FolderId = folderId ?? null;

    }

}