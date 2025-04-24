using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FolderService : IFolderService
{
    public Task<bool> CreateAsync(FolderDTO folderDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FolderService\\CreateAsync\\ " + e.Message);
        }
    }

    public Task<bool> DeleteAsync(string folderId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FolderService\\DeleteAsync\\ " + e.Message);
        }
    }

    public Task<ICollection<FolderDTO>> GetAllUserFoldersAsync(string userId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FolderService\\GetAllAsync\\ " + e.Message);
        }
    }

    public Task<FolderDTO?> GetAsync(string folderId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FolderService\\GetAsync\\ " + e.Message);
        }
    }

    public Task<bool> UpdateAsync(FolderDTO folderDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\UpdateAsync\\ " + e.Message);






        }
    }
}
