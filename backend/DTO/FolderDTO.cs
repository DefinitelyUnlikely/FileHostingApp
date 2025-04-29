using Backend.Models;

namespace Backend.DTO;

public class FolderRequest
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public ICollection<Folder>? SubFolders { get; set; }

    public string? UserId { get; set; }
}

public class FolderResponse
{

    public static FolderResponse FromModel(Folder folder)
    {
        return new FolderResponse
        {

        };
    }
}