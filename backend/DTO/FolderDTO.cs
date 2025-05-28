using Backend.Models;
using Backend.Services;

namespace Backend.DTO;



public class CreateFolderRequest
{
    public required string Name { get; set; }
    public string? UserId { get; set; }
    public Guid? ParentFolderId { get; set; }
}

public class UpdateFolderRequest
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? ParentFolderId { get; set; }
    public string? UserId { get; set; }
}

public class FolderResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public required IEnumerable<FolderResponse> SubFolders { get; set; } = [];
    public IEnumerable<FileResponse>? Files { get; set; }

    public required string UserId { get; set; }

    public static FolderResponse FromModel(Folder folder)
    {
        return new FolderResponse
        {
            Id = folder.Id,
            Name = folder.Name,
            UserId = folder.UserId,
            SubFolders = folder.SubFolders?.Select(FromModel) ?? [],
            Files = folder.Files?.Select(FileResponse.FromModel) ?? null
        };
    }
}
