// This is a model I might not need, but that I am adding the outline for
// in case of. I need to read up a bit more on EF and how projection and inclusions work
// as that might be enough for my use case while still keeping things simple. 
// If it seems like it makes things harder to understand for any other users of the code, 
// I'll go with this more simple solution. 

namespace Backend.Models;

public class FileData
{
    public string Id { get; set; }
    public string FileId { get; set; }
    public Models.File File { get; set; }

    public byte[] Bytes { get; set; }

    public FileData() { }

    public FileData(Models.File file, byte[] fileData)
    {
        Id = Guid.NewGuid().ToString();
        FileId = file.Id;
        File = file;
        Bytes = fileData;
    }
}