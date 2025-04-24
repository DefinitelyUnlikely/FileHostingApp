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
            // Validate fileDTO for required parameters
            if (fileDTO.Name is null || fileDTO.Extension is null || fileDTO.FileData is null)
            {
                return false;
            }

            Models.File file = new() { Name = fileDTO.Name, Extension = fileDTO.Extension, FileData = fileDTO.FileData, FolderId = fileDTO.FolderId };

            return await fileRepository.SaveAsync(file);

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\CreateAsync\\ " + e.Message);
        }
    }

    public async Task<bool> DeleteAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId);

            if (file is null)
            {
                return false;
            }

            return await fileRepository.DeleteAsync(file);

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\DeleteAsync\\ " + e.Message);
        }
    }

    public async Task<ICollection<FileDTO>> GetAllAsync()
    {
        try
        {
            ICollection<FileDTO> returnList = [];
            ICollection<Models.File> files = await fileRepository.GetAllAsync();

            foreach (Models.File file in files)
            {
                returnList.Add(
                    new FileDTO
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Extension = file.Extension,
                        FileData = file.FileData,
                        CreatedAt = file.CreatedAt,
                        UpdatedAt = file.UpdatedAt,
                        FolderId = file.FolderId,
                    }
                 );
            }

            return returnList;
        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetAllAsync\\ " + e.Message);
        }
    }

    public Task<FileDTO?> GetByIdAsync(Guid fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByIdAsync\\ " + e.Message);
        }
    }

    public Task<FileDTO?> GetByNameAsync(Guid fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception("\\FileService\\GetByNameAsync\\ " + e.Message);
        }
    }

    public Task<bool> UpdateAsync(FileDTO fileDTO)
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
