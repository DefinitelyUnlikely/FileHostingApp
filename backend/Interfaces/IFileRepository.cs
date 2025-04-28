using Backend.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Interfaces;

public interface IFileRepository
{
    public Task<bool> AddAsync(FileMeta fileInfo, FileData fileData);
    public Task<FileMeta?> GetByIdAsync(string fileId, bool includeData = false);
    public Task<FileMeta?> GetByNameAsync(string name, bool includeData = false);
    public Task<ICollection<FileMeta>> GetAllUserFilesAsync(string userId);
    public Task<bool> UpdateAsync();
    public Task<bool> DeleteAsync(FileMeta file);
}

