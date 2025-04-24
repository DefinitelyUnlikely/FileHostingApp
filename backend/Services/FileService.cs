using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FileService(IFileRepository fileRepository) : IFileService
{
    public async Task<bool> CreateAsync(FileDTO fileDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\CreateAsync\\ " + e.Message);
        }
    }

    public async Task<bool> DeleteAsync(string fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\DeleteAsync\\ " + e.Message);
        }
    }

    public async Task<ICollection<FileDTO>> GetAllUserFilesAsync(string userId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetAllAsync\\ " + e.Message);
        }
    }

    public async Task<FileDTO?> GetByIdAsync(string fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByIdAsync\\ " + e.Message);
        }
    }

    public async Task<FileDTO?> GetByNameAsync(string fileName)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByNameAsync\\ " + e.Message);
        }
    }

    public async Task<bool> UpdateAsync(FileDTO DTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\UpdateAsync\\ " + e.Message);
        }
    }
}
