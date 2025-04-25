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

        context.Folders.Remove(folder);
        return await context.SaveChangesAsync() != 0;

    }

    /// <summary>A method that gets and returns all folders in the current context for a specified user.</summary>
    /// <returns>An ICollection of all folder entity objects.</returns>
    public async Task<ICollection<Folder>> GetAllUserFoldersAsync(string userId)
    {

        return await context.Folders
                    .Include(f => f.SubFolders)
                    .ToListAsync();

    }

    /// <summary>A method that gets and returns a folder by specified Id.</summary>
    /// <returns>A single Folder entity object.</returns>
    public async Task<Folder?> GetAsync(string folderId)
    {

        return await context.Folders
                    .Include(f => f.SubFolders)
                    .FirstOrDefaultAsync(f => f.Id == folderId);


    }

    /// <summary>A method that takes a Folder entity object and saves it to the current context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public async Task<bool> SaveAsync(Folder folder)
    {

        await context.Folders.AddAsync(folder);
        return await context.SaveChangesAsync() != 0;

    }

    /// <summary>A method that calls SaveChangesAsync.</summary>
    /// <returns>A boolean value indicating if the save changed any entries or not.</returns>
    public async Task<bool> UpdateAsync(Folder folder)
    {
        return await context.SaveChangesAsync() != 0;
    }
}
