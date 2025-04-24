namespace Backend.Interfaces;

public interface IFolderRepository
{
    public Task<bool> SaveAsync(Models.Folder folder);
    public Task<Models.Folder?> GetAsync(Guid folderId);
    public Task<ICollection<Models.Folder>> GetAllAsync();
    public Task<bool> UpdateAsync(Models.Folder folder);
    public Task<bool> DeleteAsync(Models.Folder folder);
}