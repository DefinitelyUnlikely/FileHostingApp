using Backend.DTO;

namespace Backend.Interfaces;

public interface IFolderService
{
    public Task CreateAsync(FolderRequest request);
    public Task<FolderResponse?> GetAsync(Guid folderId);
    public Task<ICollection<FolderResponse>> GetAllUserFoldersAsync(string userId);
    public Task UpdateAsync(FolderRequest request);
    public Task DeleteAsync(Guid folderId);
}