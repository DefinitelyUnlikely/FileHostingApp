using Backend.Interfaces;
using Backend.Models;

namespace Backend.Data.Repositories;

public class FolderRepository : IFolderRepository
{
    public Task<bool> DeleteAsync(Folder folder)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Folder>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Folder> GetAsync(Guid folderId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync(Folder folder)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Folder folder)
    {
        throw new NotImplementedException();
    }
}
