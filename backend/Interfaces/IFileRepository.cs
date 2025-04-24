namespace Backend.Interfaces;

public interface IFileRepository
{
    public Task<bool> SaveAsync(Models.File file);
    public Task<Models.File?> GetByIdAsync(string fileId);
    public Task<Models.File?> GetByNameAsync(string name);
    public Task<ICollection<Models.File>> GetAllUserFilesAsync(string userId);
    public Task<bool> UpdateAsync(Models.File file);
    public Task<bool> DeleteAsync(Models.File file);
}