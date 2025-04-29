using Backend.Models;

namespace Backend.DTO;

public class FileRequest
{
    // Atm I have everything as nullable, to make the object
    // able to handle both creation and updating. One could also make the update send all required fields
    // + the new values, but if all we are updating is the name, having to send all the filedata seems 
    // unneccesery. I might change this depending on how clear the usage actually is.
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Extension { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Guid? FolderId { get; set; }
    public string? UserId { get; set; }
}


public class FileResponse
{

    public required Guid Id { get; set; }

    public required string Name { get; set; }
    public required string Extension { get; set; }

    // Nullable for when we are only sending FileMetadata
    public byte[]? FileData { get; set; }

    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }

    public Guid? FolderId { get; set; }
    public required string UserId { get; set; }

    public static FileResponse FromModel(FileMeta fileMeta)
    {
        return new FileResponse
        {
            Id = fileMeta.Id,
            Name = fileMeta.Name,
            Extension = fileMeta.Extension,
            FileData = fileMeta.FileData?.Bytes,
            CreatedAt = fileMeta.CreatedAt,
            UpdatedAt = fileMeta.UpdatedAt ?? fileMeta.CreatedAt,
            FolderId = fileMeta.FolderId,
            UserId = fileMeta.UserId
        };
    }
}