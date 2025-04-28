using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FolderService : IFolderService
{
    public Task CreateAsync(FolderDTO folderDTO)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string folderId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FolderDTO>> GetAllUserFoldersAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<FolderDTO?> GetAsync(string folderId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(FolderDTO folderDTO)
    {
        throw new NotImplementedException();
    }
}
