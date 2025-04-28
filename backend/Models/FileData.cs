namespace Backend.Models;

public class FileData
{
    public string Id { get; set; }
    public string FileId { get; set; }
    public FileInfo File { get; set; }

    public byte[] Bytes { get; set; }

    public FileData() { }

    public FileData(FileInfo file, byte[] fileData)
    {
        Id = Guid.NewGuid().ToString();
        FileId = file.Id;
        File = file;
        Bytes = fileData;
    }
}