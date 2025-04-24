using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FolderService : IFolderService
{
    public Task<bool> CreateAsync(FolderDTO folderDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid folderId)
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

    public Task<Folder> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(FolderDTO folderDTO)
    {
        throw new NotImplementedException();
    }
}
