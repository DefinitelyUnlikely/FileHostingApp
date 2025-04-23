namespace Backend.Models;

public class Folder
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }

    public ICollection<Folder> SubFolders { get; set; } = [];

    public Folder() { }

    public Folder(string name, Folder? parentFolder)
    {
        Name = name;
        ParentFolder = parentFolder;
        ParentFolderId = parentFolder?.Id;
    }

}