namespace Backend.Interfaces;

public interface IFolderRepository
{
    public Task<bool> AddAsync(Models.Folder folder);
    public Task<Models.Folder?> GetAsync(Guid folderId, bool includeFiles = false);
    public Task<ICollection<Models.Folder>> GetAllUserFoldersAsync(string userId, bool includeFiles = false);
    public Task<Models.Folder> GetRootAsync(string userId, bool includeFiles = false);
    public Task<bool> UpdateAsync();
    public Task<bool> DeleteAsync(Models.Folder folder);
}