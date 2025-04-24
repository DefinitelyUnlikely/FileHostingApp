using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class Folder
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public ICollection<Folder> SubFolders { get; set; } = [];

    public required string UserId { get; set; }
    public required IdentityUser User { get; set; }

}