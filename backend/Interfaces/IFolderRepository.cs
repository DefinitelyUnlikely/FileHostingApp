namespace Backend.Interfaces;

public interface IFolderRepository
{
    public Task<bool> SaveAsync(Models.Folder folder);
    public Task<Models.Folder?> GetAsync(string folderId);
    public Task<ICollection<Models.Folder>> GetAllUserFoldersAsync(string userId);
    public Task<bool> UpdateAsync(Models.Folder folder);
    public Task<bool> DeleteAsync(Models.Folder folder);
}