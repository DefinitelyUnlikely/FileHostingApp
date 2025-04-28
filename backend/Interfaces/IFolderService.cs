namespace Backend.Interfaces;

public interface IFolderService
{
    public Task CreateAsync(DTO.FolderDTO folderDTO);
    public Task<DTO.FolderDTO?> GetAsync(Guid folderId);
    public Task<ICollection<DTO.FolderDTO>> GetAllUserFoldersAsync(string userId);
    public Task UpdateAsync(DTO.FolderDTO folderDTO);
    public Task DeleteAsync(Guid folderId);
}