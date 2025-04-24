namespace Backend.DTO;

public class FolderDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Models.Folder? ParentFolder { get; set; }

    public ICollection<Models.Folder>? SubFolders { get; set; }

    public string? UserId { get; set; }
}