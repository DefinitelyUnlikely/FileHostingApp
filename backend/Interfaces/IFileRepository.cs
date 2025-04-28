using Backend.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Interfaces;

public interface IFileRepository
{
    public Task<bool> AddAsync(Models.FileInfo fileInfo, FileData fileData);
    public Task<Models.FileInfo?> GetByIdAsync(string fileId, bool includeData = false);
    public Task<Models.FileInfo?> GetByNameAsync(string name, bool includeData = false);
    public Task<ICollection<Models.FileInfo>> GetAllUserFilesAsync(string userId);
    public Task<bool> UpdateAsync();
    public Task<bool> DeleteAsync(Models.FileInfo file);
}

