using Backend.DTO;
using Backend.Interfaces;

namespace Backend.Services;

public class FileService : IFileService
{
    public Task<bool> CreateAsync(FileDTO fileDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid fileId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Models.File>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Models.File> GetAsync(Guid fileId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(FileDTO fileDTO)
    {
        throw new NotImplementedException();
    }
}
