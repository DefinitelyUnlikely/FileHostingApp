using System.Reflection.Metadata.Ecma335;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ICollection<Folder>> GetAllAsync()
    {
        try
        {
            return await context.Folders.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\GetAllAsync: " + e.Message);
        }
    }

    /// <summary>A method that gets and returns a folder by specified Id.</summary>
    /// <returns>A single Folder entity object.</returns>
    public async Task<Folder?> GetAsync(Guid folderId)
    {
        try
        {
            return await context.Folders.FirstOrDefaultAsync(f => f.Id == folderId);
        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\GetAsync: " + e.Message);
        }
    }

    /// <summary>A method that takes a Folder entity object and saves it to the current context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public async Task<bool> SaveAsync(Folder folder)
    {
        try
        {
            await context.Folders.AddAsync(folder);
            return await context.SaveChangesAsync() != 0;
        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\SaveAsync: " + e.Message);
        }
    }

    /// <summary>A method that calls SaveChangesAsync.</summary>
    /// <returns>A boolean value indicating if the save changed anything or not.</returns>
    public async Task<bool> UpdateAsync(Folder folder)
    {
        try
        {
            return await context.SaveChangesAsync() != 0;
        }
        catch (Exception e)
        {
            throw new Exception("\\FolderRepository\\UpdatetAsync: " + e.Message);
        }
    }
}
