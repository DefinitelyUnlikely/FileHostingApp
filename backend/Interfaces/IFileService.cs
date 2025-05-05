using Backend.DTO;

namespace Backend.Interfaces;

public interface IFileService
{
    public Task CreateAsync(CreateFileRequest request);
    public Task<FileResponse?> GetByIdAsync(Guid fileId);
    public Task<FileResponse?> GetByNameAsync(string fileName);
    public Task<ICollection<FileResponse>> GetAllUserFilesAsync(string userId);
    public Task UpdateAsync(UpdateFileRequest request);
    public Task DeleteAsync(Guid fileId);
}