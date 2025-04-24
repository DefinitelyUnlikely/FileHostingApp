namespace Backend.Interfaces;

public interface IFolderService
{
    public Task<bool> CreateAsync(DTO.FolderDTO folderDTO);
    public Task<DTO.FolderDTO?> GetAsync(string folderId);
    public Task<ICollection<DTO.FolderDTO>> GetAllUserFoldersAsync(string userId);
    public Task<bool> UpdateAsync(DTO.FolderDTO folderDTO);
    public Task<bool> DeleteAsync(string folderId);
}