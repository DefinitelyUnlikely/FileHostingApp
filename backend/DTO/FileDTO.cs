using Backend.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Backend.DTO;

public interface IFileRequest;

public class CreateFileRequest : IFileRequest
{
    public required string Name { get; set; }
    public required string Extension { get; set; }
    public required byte[] FileData { get; set; }

    public string? UserId { get; set; }
    public Guid? FolderId { get; set; }
}

public class UpdateFileRequest : IFileRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Extension { get; set; }

    public byte[]? FileData { get; set; }

    public Guid? FolderId { get; set; }
    public string? UserId { get; set; } //Do we allow updating which user owns a file?
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
