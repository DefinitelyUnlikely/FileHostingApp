using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories;


public class FileRepository(ApplicationDbContext context) : IFileRepository
{
    /// <summary>Delete the, by EntityFrameWork, tracked file given as an argument.</summary>
    /// <returns>A boolean value indicating if the deletion was successful or not.</returns>
    public async Task<bool> DeleteAsync(Models.File file)
    {

        context.Files.Remove(file);
        return await context.SaveChangesAsync() != 0;

    }

    /// <summary>A method that gets and returns all files in the current context for a specified user.</summary>
    /// <returns>An ICollection of all file entity objects.</returns>
    public async Task<ICollection<Models.File>> GetAllUserFilesAsync(string userId)
    {

        return await context.Files.ToListAsync();

    }

    /// <summary>A method that gets and returns a file by specified Id.</summary>
    /// <returns>A single file entity object.</returns>
    public async Task<Models.File?> GetByIdAsync(string fileId)
    {

        return await context.Files.FirstOrDefaultAsync(f => f.Id == fileId);

    }

    /// <summary>A method that gets and returns a file by specified name.</summary>
    /// <returns>A single file entity object.</returns>
    public async Task<Models.File?> GetByNameAsync(string name)
    {

        return await context.Files.FirstOrDefaultAsync(f => f.Name == name);

    }

    /// <summary>A method that takes a file entity object and saves it to the current context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public async Task<bool> SaveAsync(Models.File file)
    {

        await context.Files.AddAsync(file);
        return await context.SaveChangesAsync() != 0;

    }

    /// <summary>A method that takes a tracked file entity object and saves it to the context.</summary>
    /// <returns>A boolean value indicating if the save changed any entries or not.</returns>
    public async Task<bool> UpdateAsync(Models.File file)
    {

        return await context.SaveChangesAsync() != 0;

    }
}