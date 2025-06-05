using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services;

public class FolderService(ILogger<FolderService> logger, IFolderRepository folderRepository, IAuthService userAuthService) : IFolderService
{
    /// <summary>
    /// Creates a folder from a CreateFolderRequest and sends it to the repository for saving to the context.
    /// </summary>
    /// <param name="request">A CreateFolderRequest object</param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="NoChangesSavedException">Thrown when the repository fails to save to database context.</exception>
    public async Task CreateAsync(CreateFolderRequest request)
    {
        try
        {
            request.UserId ??= userAuthService.UserId;

            if (userAuthService.UserId != request.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            if (request.ParentFolderId is not null)
            {
                FolderResponse? parentFolder = await GetAsync((Guid)request.ParentFolderId);
                if (userAuthService.UserId != parentFolder?.UserId)
                {
                    throw new UnauthorizedAccessException();
                }
            }

            var folder = new Folder
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentFolderId = request.ParentFolderId,
                UserId = request.UserId ?? throw new ArgumentException("No user id was given, and no user was found using the token data."),
                SubFolders = [],
                Files = [],
            };

            if (!await folderRepository.AddAsync(folder)) throw new NoChangesSavedException("No folder has been saved to the database.");

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
        catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
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
    /// Calls the repository to attempt to remove a folder.
    /// </summary>
    /// <param name="folderId">A GUID id for a specific folder</param>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    /// <exception cref="NoChangesSavedException">Thrown when the repository fails to save to database context.</exception>
    public async Task DeleteAsync(Guid folderId)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId) ?? throw new EmptyReturnException("No folder with that Id was found.");

            if (userAuthService.UserId != folder.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            if (!await folderRepository.DeleteAsync(folder)) throw new NoChangesSavedException("No folder has been deleted.");
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
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// Gets all folders fora specific user id, returning a list of folders and their subfolders (depth of 1). 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="includeFiles"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task<ICollection<FolderResponse>> GetAllUserFoldersAsync(string userId, bool includeFiles = false)
    {
        try
        {
            if (userAuthService.UserId != userId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            var folders = await folderRepository.GetAllUserFoldersAsync(userId, includeFiles);

            if (folders is null || folders.Count == 0) throw new EmptyReturnException("No folders where found for this user");

            List<FolderResponse> returnFolders = [];
            foreach (var folder in folders)
            {
                returnFolders.Add(FolderResponse.FromModel(folder));
            }

            return returnFolders;

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
    /// Gets a folder by its id. 
    /// </summary>
    /// <param name="folderId"></param>
    /// <param name="includeFiles"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task<FolderResponse?> GetAsync(Guid folderId, bool includeFiles = false)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId, includeFiles) ?? throw new EmptyReturnException("No folder was retreived");

            if (userAuthService.UserId != folder.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            return FolderResponse.FromModel(folder);
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
    /// Gets the root folder for a specified user id. 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="includeFiles">Boolean, if set to true, file metadata will be included in the response.</param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    public async Task<FolderResponse?> GetRootAsync(string userId, bool includeFiles = false)
    {
        try
        {
            if (userAuthService.UserId != userId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            var root = await folderRepository.GetRootAsync(userId, includeFiles) ?? throw new EmptyReturnException("No folder was retreived");
            return FolderResponse.FromModel(root);
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
    /// Attempts to update a folder with the provided UpdateFolderRequest properties. Properties not provided will default to current values for the folder that is being updated.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when the user in the current HttpContext is not the owner of the resource or has elevated access.</exception>
    /// <exception cref="EmptyReturnException">Thrown when the repository fails to return any data, either because no data exists or because an error has occured.</exception>
    /// <exception cref="NoChangesSavedException">Thrown when the repository fails to save to database context.</exception>
    public async Task UpdateAsync(UpdateFolderRequest request)
    {
        try
        {
            request.UserId ??= userAuthService.UserId;

            if (userAuthService.UserId != request.UserId && !userAuthService.UserIsAdmin) throw new UnauthorizedAccessException();

            var folder = await folderRepository.GetAsync(request.Id) ?? throw new EmptyReturnException("No folder found with that Id");

            if (folder.UserId != userAuthService.UserId) throw new UnauthorizedAccessException();

            folder.Name = request.Name ?? folder.Name;
            folder.ParentFolderId = request.ParentFolderId ?? folder.ParentFolderId;
            folder.UserId = request.UserId ?? folder.UserId;

            if (!await folderRepository.UpdateAsync()) throw new NoChangesSavedException("Folder could not be updated.");

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
