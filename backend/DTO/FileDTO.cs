namespace Backend.DTO;

public class FileDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Extension { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Guid? FolderId { get; set; }
    public Models.Folder? Folder { get; set; }
}