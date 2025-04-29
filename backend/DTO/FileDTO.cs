using Backend.Models;

namespace Backend.DTO;

public class FileRequest
{
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
    public static FileResponse FromModel(FileMeta fileMeta, FileData fileData)
    {
        return new FileResponse { };
    }
}