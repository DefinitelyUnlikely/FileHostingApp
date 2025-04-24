namespace Backend.Interfaces;

public interface IFolderService
{
    public Task<bool> CreateAsync(DTO.FolderDTO folderDTO);
    public Task<DTO.FolderDTO?> GetAsync(Guid folderId);
    public Task<ICollection<DTO.FolderDTO>> GetAllAsync();
    public Task<bool> UpdateAsync(DTO.FolderDTO folderDTO);
    public Task<bool> DeleteAsync(Guid folderId);
}