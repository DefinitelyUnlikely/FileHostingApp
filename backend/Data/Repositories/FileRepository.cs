using Backend.Interfaces;

namespace Backend.Data.Repositories;


public class FileRepository : IFileRepository
{
    public Task<bool> DeleteAsync(Models.File file)
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

    public Task<Models.File> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync(Models.File file)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Models.File file)
    {
        throw new NotImplementedException();
    }
}