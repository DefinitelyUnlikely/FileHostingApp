using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class Folder
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public string? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public required ICollection<Folder> SubFolders { get; set; }

    public required string UserId { get; set; }
    public required IdentityUser User { get; set; }

    // For EF
    public Folder() { }

    // For new folders
    public Folder(string name, string userId, string? parentId = null, ICollection<Folder>? subFolders = null)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        ParentFolderId = parentId ?? null;
        SubFolders = subFolders ?? [];
    }
}