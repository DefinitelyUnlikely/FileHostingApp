namespace Backend.Models;

public class FileData
{
    public required string Id { get; set; }
    public required string FileId { get; set; }
    public FileInfo File { get; set; }

    public required byte[] Bytes { get; set; }

    public FileData() { }

    public FileData(string fileId, byte[] fileData)
    {
        Id = Guid.NewGuid().ToString();
        FileId = fileId;
        Bytes = fileData;
    }
}