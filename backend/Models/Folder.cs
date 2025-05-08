using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Models;

public class Folder
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public required string UserId { get; set; }
    public IdentityUser? User { get; set; }

    public required ICollection<Folder> SubFolders { get; set; }
    public required ICollection<FileMeta> Files { get; set; }

    public Guid ParentFolderIdProxy { get; private set; }

}