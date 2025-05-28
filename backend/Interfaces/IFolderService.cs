using Backend.DTO;

namespace Backend.Interfaces;

public interface IFolderService
{
    public Task CreateAsync(CreateFolderRequest request);
    public Task<FolderResponse?> GetAsync(Guid folderId, bool includeFiles = false);
    public Task<ICollection<FolderResponse>> GetAllUserFoldersAsync(string userId, bool includeFiles = false);
    public Task UpdateAsync(UpdateFolderRequest request);
    public Task DeleteAsync(Guid folderId);
}