namespace Backend.Models;

public class FileData
{
    public required Guid Id { get; set; }
    public required Guid FileId { get; set; }
    public FileMeta? File { get; set; }

    public required byte[] Bytes { get; set; }
}