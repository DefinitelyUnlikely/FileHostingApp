namespace Backend.Interfaces;

public interface IFileRepository
{
    public Task<bool> SaveFileAsync();
    public Task<Models.File> GetFileAsync();
    public Task<ICollection<Models.File>> GetAllFilesAsync();
    public Task<bool> UpdateFile(Models.File file);
    public Task<bool> DeleteFile(Models.File file);
}