using System.Data;
using System.Reflection;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FileService(ILogger<FileService> logger, IFileRepository fileRepository, IAuthService userAuthService) : IFileService
{
    public async Task CreateAsync(CreateFileRequest request)
    {
        try
        {

            request.UserId ??= userAuthService.UserId;

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != request.UserId) throw new UnauthorizedAccessException();

            var fileMeta = new FileMeta
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Extension = request.Extension,
                CreatedAt = DateTime.UtcNow,
                UserId = request.UserId ?? throw new ArgumentException("No user id was given, and no user was found using the token data."),
                FileSize = request.FileData.Length * 8,
            };
            var fileData = new FileData
            {
                Id = Guid.NewGuid(),
                FileMetaId = fileMeta.Id,
                Bytes = request.FileData,
            };

            if (!await fileRepository.AddAsync(fileMeta, fileData)) throw new NoChangesSavedException("No file could be saved.");

        }
        catch (UnauthorizedAccessException e)
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

    public async Task DeleteAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId) ?? throw new EmptyReturnException("No file with that Id was found");

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != file.UserId) throw new UnauthorizedAccessException();

            await fileRepository.DeleteAsync(file);
        }
        catch (UnauthorizedAccessException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
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

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != userId) throw new UnauthorizedAccessException();

            var files = (List<FileMeta>)await fileRepository.GetAllUserFilesAsync(userId);

            if (files.Count == 0) throw new EmptyReturnException("The returned list or object is empty.");

            return [.. files.Select(FileResponse.FromModel)];
        }
        catch (UnauthorizedAccessException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
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
            var file = await fileRepository.GetByIdAsync(fileId, includeData: true) ?? throw new EmptyReturnException("No file with that Id was found.");

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != file.UserId) throw new UnauthorizedAccessException();

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was found or could not be included");
            }

            return FileResponse.FromModel(file);
        }
        catch (UnauthorizedAccessException e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
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

    public async Task<FileResponse?> GetByNameAsync(string fileName)
    {
        try
        {
            var file = await fileRepository.GetByNameAsync(fileName, true) ?? throw new EmptyReturnException("No file with that name was found.");

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != file.UserId) throw new UnauthorizedAccessException();

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was not found or could not be included");
            }

            return FileResponse.FromModel(file);
        }
        catch (UnauthorizedAccessException e)
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

    public async Task UpdateAsync(UpdateFileRequest request)
    {
        try
        {
            request.UserId ??= userAuthService.UserId;

            if (!userAuthService.UserIsAdmin && userAuthService.UserId != request.UserId) throw new UnauthorizedAccessException();

            var file = await fileRepository.GetByIdAsync(request.Id, includeData: true) ?? throw new EmptyReturnException("No file with that Id was found");

            file.Name = request.Name ?? file.Name;
            file.Extension = request.Extension ?? file.Extension;
            file.FileData!.Bytes = request.FileData ?? file.FileData.Bytes; // Might want to add a getFileData method to our repo
            file.FileSize = request.FileData?.Length ?? file.FileData.Bytes.Length;
            file.UpdatedAt = DateTime.UtcNow;
            file.FolderId = request.FolderId ?? file.FolderId;

            if (!await fileRepository.UpdateAsync()) throw new NoChangesSavedException("File could not be updated.");
        }
        catch (UnauthorizedAccessException e)
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
