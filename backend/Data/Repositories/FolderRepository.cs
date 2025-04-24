using Backend.Interfaces;
using Backend.Models;

namespace Backend.Data.Repositories;

public class FolderRepository(ApplicationDbContext context) : IFolderRepository
{

    /// <summary>Delete the, by EntityFrameWork, tracked folder given as an argument.</summary>
    /// <returns>A boolean value indicating if the deletion was successful or not.</returns>
    public async Task<bool> DeleteAsync(Folder folder)
    {
        try
        {
            context.Folders.Remove(folder);
            return await context.SaveChangesAsync() != 0;
        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\DeleteAsync: " + e.Message);
        }
    }

    /// <summary>A method that gets and returns all folders in the current context.</summary>
    /// <returns>An ICollection of all folder entity objects.</returns>
    public Task<ICollection<Folder>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that gets and returns a folder by specified Id.</summary>
    /// <returns>A single Folder entity object.</returns>
    public Task<Folder> GetAsync(Guid folderId)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that takes a Folder entity object and saves it to the current context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public Task<bool> SaveAsync(Folder folder)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that takes a tracked Folder entity object and saves it to the context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public Task<bool> UpdateAsync(Folder folder)
    {
        throw new NotImplementedException();
    }
}
