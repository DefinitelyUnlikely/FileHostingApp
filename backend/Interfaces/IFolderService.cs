namespace Backend.Interfaces;

public interface IFolderService
{
    public Task<bool> CreateAsync(DTO.FolderDTO folderDTO);
    public Task<Models.Folder> GetAsync(Guid folderId);
    public Task<Models.Folder> GetByNameAsync(string name); // Uncertain if I need this for folders?
    public Task<ICollection<Models.Folder>> GetAllAsync();
    public Task<bool> UpdateAsync(DTO.FolderDTO folderDTO);
    public Task<bool> DeleteAsync(Guid folderId);
}