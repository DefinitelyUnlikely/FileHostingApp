namespace Backend.DTO;

public class FileDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Extension { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string? FolderId { get; set; }
    public string? UserId { get; set; }
}