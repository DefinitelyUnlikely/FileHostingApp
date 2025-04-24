using Backend.DTO;
using Backend.Interfaces;

namespace Backend.Services;

public class FileService : IFileService
{
    public Task<bool> CreateAsync(FileDTO fileDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\CreateAsync: " + e.Message);
        }
    }

    public Task<bool> DeleteAsync(Guid fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\DeleteAsync: " + e.Message);
        }
    }

    public Task<ICollection<FileDTO>> GetAllAsync()
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetAllAsync: " + e.Message);
        }
    }

    public Task<FileDTO?> GetByIdAsync(Guid fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByIdAsync: " + e.Message);
        }
    }

    public Task<FileDTO?> GetByNameAsync(Guid fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByNameAsync: " + e.Message);
        }
    }

    public Task<bool> UpdateAsync(FileDTO fileDTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\UpdateAsync: " + e.Message);
        }
    }
}
