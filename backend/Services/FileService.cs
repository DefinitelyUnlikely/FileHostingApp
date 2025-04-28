using System.Data;
using System.Reflection;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FileService(ILogger<FileService> logger, IFileRepository fileRepository) : IFileService
{
    public async Task CreateAsync(FileDTO fileDTO)
    {
        try
        {

            var fileInfo = new FileMeta();

            var fileData = new FileData();

            if (!await fileRepository.AddAsync(fileInfo, fileData)) throw new NoChangesSavedException("Nothing was added to the context");


        }
        catch (NoChangesSavedException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task DeleteAsync(string fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task<ICollection<FileDTO>> GetAllUserFilesAsync(string userId)
    {
        try
        {
            var files = (List<FileMeta>)await fileRepository.GetAllUserFilesAsync(userId);

            if (files.Count == 0) throw new EmptyReturnException("The returned list or object is empty");

            List<FileDTO> fileDTOs = [];
            foreach (var file in files)
            {
                fileDTOs.Add(
                    new FileDTO
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Extension = file.Extension,
                        CreatedAt = file.CreatedAt,
                        UpdatedAt = file.UpdatedAt,
                        FolderId = file.FolderId,
                        UserId = file.UserId,
                    }
                );
            }

            return fileDTOs;
        }
        catch (EmptyReturnException)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task<FileDTO?> GetByIdAsync(string fileId)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new RepositoryException(e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public async Task<FileDTO?> GetByNameAsync(string fileName)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "StackTrace" + e.StackTrace);
        }
    }

    public async Task UpdateAsync(FileDTO DTO)
    {
        try
        {

        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "StackTrace" + e.StackTrace);
        }
    }
}
