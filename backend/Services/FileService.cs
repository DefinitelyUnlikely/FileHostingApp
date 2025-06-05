using System.Data;
using System.Reflection;
using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FileService(ILogger<FileService> logger, IFileRepository fileRepository, IFolderService folderService, IAuthService userAuthService) : IFileService
{

    /// <summary>
    /// Creates a file from a CreateFileRequest class object and sends it to the repository to be added to the database context. 
    /// </summary>
    /// <param name="request">The CreateFileRequest object.</param>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="NoChangesSavedException">Thrown when the repository fails to save to database context.</exception>
    public async Task CreateAsync(CreateFileRequest request)
    {
        try
        {

            request.UserId ??= userAuthService.UserId;

            if (request.FolderId is not null)
            {
                FolderResponse? folder = await folderService.GetAsync((Guid)request.FolderId);
                if (folder?.UserId != userAuthService.UserId)
                {
                    throw new UnauthorizedAccessException();
                }
            }

            if (userAuthService.UserId != request.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            var fileMeta = new FileMeta
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Extension = request.Extension,
                CreatedAt = DateTime.UtcNow,
                FolderId = request.FolderId ?? null,
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

    /// <summary>
    /// Removes a file from the database context. 
    /// </summary>
    /// <param name="fileId">The id for the specific file to remove from the database context.</param>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task DeleteAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId) ?? throw new EmptyReturnException("No file with that Id was found");

            if (userAuthService.UserId != file.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

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

    /// <summary>
    /// Gets all files for a specific userId and returns the File Metadata for all files. 
    /// </summary>
    /// <param name="userId">The id </param>
    /// <returns>A ICollection of FileResponses for a given user.</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task<ICollection<FileResponse>> GetAllUserFilesAsync(string userId)
    {
        try
        {

            if (userAuthService.UserId != userId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

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

    /// <summary>
    /// Gets a specific file from the repository and returns it, with both metadata and data. 
    /// </summary>
    /// <param name="fileId"></param>
    /// <returns>A FileResponse object with corresponding filedata included.</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task<FileResponse?> GetByIdAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId, includeData: true) ?? throw new EmptyReturnException("No file with that Id was found.");

            if (userAuthService.UserId != file.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

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

    /// <summary>
    /// Attempts to get a file from the repository using its name. 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>A FileResponse object with corresponding filedata included.</returns>
    /// <exception cref="EmptyReturnException"></exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    public async Task<FileResponse?> GetByNameAsync(string fileName)
    {
        try
        {
            var file = await fileRepository.GetByNameAsync(fileName, true) ?? throw new EmptyReturnException("No file with that name was found.");

            if (userAuthService.UserId != file.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

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

    /// <summary>
    /// Attempts to update a file using the information in the UpdateFileRequest object.
    /// </summary>
    /// <param name="request">A UpdateFileRequest object with the fields to update.</param>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    /// <exception cref="NoChangesSavedException">Thrown when the repository fails to save to database context.</exception>
    public async Task UpdateAsync(UpdateFileRequest request)
    {
        try
        {
            request.UserId ??= userAuthService.UserId;

            if (userAuthService.UserId != request.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            var file = await fileRepository.GetByIdAsync(request.Id, includeData: true) ?? throw new EmptyReturnException("No file with that Id was found");

            if (file.UserId != userAuthService.UserId) throw new UnauthorizedAccessException();

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
