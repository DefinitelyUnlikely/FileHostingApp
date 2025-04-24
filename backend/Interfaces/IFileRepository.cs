namespace Backend.Interfaces;

public interface IFileRepository
{
    public Task<bool> SaveAsync(Models.File file);
    public Task<Models.File> GetAsync(Guid fileId);
    public Task<Models.File> GetByNameAsync(string name);
    public Task<ICollection<Models.File>> GetAllAsync();
    public Task<bool> UpdateAsync(Models.File file);
    public Task<bool> DeleteAsync(Models.File file);
}