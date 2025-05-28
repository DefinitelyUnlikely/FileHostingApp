using System.Reflection.Metadata.Ecma335;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories;

public class FolderRepository(ApplicationDbContext context) : IFolderRepository
{

    public async Task<bool> DeleteAsync(Folder folder)
    {

        context.Folders.Remove(folder);
        return await context.SaveChangesAsync() != 0;

    }

    public async Task<ICollection<Folder>> GetAllUserFoldersAsync(string userId, bool includeFiles = false)
    {
        IQueryable<Folder> query = context.Folders
        .Where(f => f.UserId == userId)
        .Include(f => f.SubFolders);

        if (includeFiles)
        {
            query = query.Include(f => f.Files);
        }

        return await query.ToListAsync();
    }

    public async Task<Folder?> GetAsync(Guid folderId, bool includeFiles = false)
    {

        IQueryable<Folder> query = context.Folders
        .Include(f => f.SubFolders);

        if (includeFiles)
        {
            query = query.Include(f => f.Files);
        }

        return await query.FirstOrDefaultAsync(f => f.Id == folderId);
    }

    public async Task<bool> AddAsync(Folder folder)
    {

        await context.Folders.AddAsync(folder);
        return await context.SaveChangesAsync() != 0;

    }

    public async Task<bool> UpdateAsync()
    {
        return await context.SaveChangesAsync() != 0;
    }

    public async Task<Folder> GetRootAsync(string userId, bool includeFiles = false)
    {
        List<FileMeta> files = [];
        var subFolders = await context.Folders
        .Where(folder => folder.UserId == userId && folder.ParentFolderId == null)
        .ToListAsync();

        if (includeFiles)
        {
            files = await context.Files
            .Where(file => file.UserId == userId && file.FolderId == null)
            .ToListAsync();
        }

        return new Folder
        {
            Id = Guid.Empty,
            Name = "root",
            UserId = userId,
            SubFolders = subFolders,
            Files = files
        };

    }
}
