namespace Backend.DTO;

public class FolderDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }

    public string? ParentFolderId { get; set; }
    public Models.Folder? ParentFolder { get; set; }

    public ICollection<Models.Folder>? SubFolders { get; set; }

    public string? UserId { get; set; }
}