using System.Data;
using System.Reflection;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FileService(ILogger<FileService> logger, IFileRepository fileRepository) : IFileService
{
    public async Task CreateAsync(FileRequest request)
    {
        try
        {
            // Validate that all required data to create a new file exists in the DTO
            if (request.Name is null || request.Extension is null || request.UserId is null || request.FileData is null)
            {
                throw new ArgumentException("Not all required data has been provided.");
            }

            // Might change these to use constructors instead and removing the required keyword
            // from the properties. Will have to see what I find gives most clarity to the reader of the code.
            var fileInfo = new FileMeta
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Extension = request.Extension,
                CreatedAt = DateTime.UtcNow,
                UserId = request.UserId
            };
            var fileData = new FileData
            {
                Id = Guid.NewGuid(),
                FileMetaId = fileInfo.Id,
                Bytes = request.FileData
            };

            if (!await fileRepository.AddAsync(fileInfo, fileData)) throw new NoChangesSavedException("No file could be saved.");

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

    public async Task DeleteAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId) ?? throw new EmptyReturnException("No file with that Id was found");
            await fileRepository.DeleteAsync(file);
        }
        catch (EmptyReturnException e)
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

    public async Task<ICollection<FileResponse>> GetAllUserFilesAsync(string userId)
    {
        try
        {
            var files = (List<FileMeta>)await fileRepository.GetAllUserFilesAsync(userId);

            if (files.Count == 0) throw new EmptyReturnException("The returned list or object is empty.");

            return [.. files.Select(file => FileResponse.FromModel(file))];
        }
        catch (EmptyReturnException e)
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

    public async Task<FileResponse?> GetByIdAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId, true) ?? throw new EmptyReturnException("No file with that Id was found.");

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was not found or could not be included");
            }

            return FileResponse.FromModel(file);
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task<FileResponse?> GetByNameAsync(string fileName)
    {
        try
        {
            var file = await fileRepository.GetByNameAsync(fileName, true) ?? throw new EmptyReturnException("No file with that name was found.");

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was not found or could not be included");
            }

            return FileResponse.FromModel(file);
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task UpdateAsync(FileRequest request)
    {
        try
        {
            if (request.Id is null) throw new ArgumentException("Missing Id");
            var file = await fileRepository.GetByIdAsync((Guid)request.Id) ?? throw new EmptyReturnException("No file with that Id was found");

            file.Name = request.Name ?? file.Name;
            file.Extension = request.Extension ?? file.Extension;
            file.FileData.Bytes = request.FileData ?? file.FileData.Bytes; // Might want to add a getFileData method to our repo
            file.CreatedAt = request.CreatedAt ?? file.CreatedAt;
            file.UpdatedAt = DateTime.UtcNow;
            file.FolderId = request.FolderId ?? file.FolderId;


            if (!await fileRepository.UpdateAsync()) throw new NoChangesSavedException("File could not be updated.");
        }
        catch (ArgumentException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
        catch (EmptyReturnException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
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
}
