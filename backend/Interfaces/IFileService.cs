using Backend.DTO;

namespace Backend.Interfaces;

public interface IFileService
{
    public Task CreateAsync(FileRequest request);
    public Task<FileResponse?> GetByIdAsync(Guid fileId);
    public Task<FileResponse?> GetByNameAsync(string fileName);
    public Task<ICollection<FileResponse>> GetAllUserFilesAsync(string userId);
    public Task UpdateAsync(FileRequest request);
    public Task DeleteAsync(Guid fileId);
}