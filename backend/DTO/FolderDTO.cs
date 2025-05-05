using Backend.Models;

namespace Backend.DTO;


public interface IFolderRequest;

public class CreateFolderRequest : IFolderRequest
{
    public required string Name { get; set; }
    public required string UserId { get; set; }
    public Guid? ParentFolderId { get; set; }

}

public class UpdateFolderRequest : IFolderRequest
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? ParentFolderId { get; set; }
    public string? UserId { get; set; }
}

// public class FolderRequest
// {
//     public Guid? Id { get; set; }
//     public string? Name { get; set; }

//     public Guid? ParentFolderId { get; set; }
//     public Folder? ParentFolder { get; set; }

//     public ICollection<Folder>? SubFolders { get; set; }

//     public string? UserId { get; set; }
// }

public class FolderResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public ICollection<Folder>? SubFolders { get; set; }

    public required string UserId { get; set; }

    public static FolderResponse FromModel(Folder folder)
    {
        return new FolderResponse
        {
            Id = folder.Id,
            Name = folder.Name,
            UserId = folder.UserId,
            ParentFolderId = folder.ParentFolderId,
            ParentFolder = folder.ParentFolder,
            SubFolders = folder.SubFolders,
        };
    }
}