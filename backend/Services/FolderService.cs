using Backend.DTO;
using Backend.Exceptions;
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
            throw new RepositoryException("Repository error: " + e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public Task<bool> DeleteAsync(string folderId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new RepositoryException("Repository error: " + e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public Task<ICollection<FolderDTO>> GetAllUserFoldersAsync(string userId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new RepositoryException("Repository error: " + e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public Task<FolderDTO?> GetAsync(string folderId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new RepositoryException("Repository error: " + e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public Task<bool> UpdateAsync(FolderDTO folderDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new RepositoryException("Repository error: " + e.Message + "StackTrace" + e.StackTrace);
        }
    }
}
