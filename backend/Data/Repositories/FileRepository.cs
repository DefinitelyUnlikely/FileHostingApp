using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories;


public class FileRepository(ApplicationDbContext context) : IFileRepository
{

    public async Task<bool> AddAsync(Models.FileInfo fileInfo, FileData fileData)
    {
        await context.Files.AddAsync(fileInfo);
        await context.FilesData.AddAsync(fileData);
        return await context.SaveChangesAsync() != 0;
    }

    public async Task<bool> DeleteAsync(Models.FileInfo file)
    {
        context.Remove(file);
        return await context.SaveChangesAsync() != 0;
    }

    public async Task<ICollection<Models.FileInfo>> GetAllUserFilesAsync(string userId)
    {
        return await context.Files.ToListAsync();
    }

    public async Task<Models.FileInfo?> GetByIdAsync(string fileId, bool includeData = false)
    {
        if (includeData)
        {
            return await context.Files.Include(f => f.FileData).FirstOrDefaultAsync(f => f.Id == fileId);
        }

        return await context.Files.FirstOrDefaultAsync(f => f.Id == fileId);
    }

    public async Task<Models.FileInfo?> GetByNameAsync(string name, bool includeData = false)
    {
        if (includeData)
        {
            return await context.Files.Include(f => f.FileData).FirstOrDefaultAsync(f => f.Name == name);
        }

        return await context.Files.FirstOrDefaultAsync(f => f.Name == name);
    }


    public async Task<bool> UpdateAsync()
    {
        return await context.SaveChangesAsync() != 0;
    }
}