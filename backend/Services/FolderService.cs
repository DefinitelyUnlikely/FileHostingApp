using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services;

public class FolderService(ILogger<FolderService> logger, IFolderRepository folderRepository, IAuthService userAuthService) : IFolderService
{
    public async Task CreateAsync(CreateFolderRequest request)
    {
        try
        {

            if (!userAuthService.UserIsAdmin || userAuthService.UserId != request.UserId) throw new UnauthorizedAccessException();

            var folder = new Folder
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentFolderId = request.ParentFolderId,
                UserId = request.UserId,
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

    public async Task DeleteAsync(Guid folderId)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId) ?? throw new EmptyReturnException("No folder with that Id was found.");

            if (!userAuthService.UserIsAdmin || userAuthService.UserId != folder.UserId) throw new UnauthorizedAccessException();

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

    public async Task<ICollection<FolderResponse>> GetAllUserFoldersAsync(string userId)
    {
        try
        {
            if (!userAuthService.UserIsAdmin || userAuthService.UserId != userId) throw new UnauthorizedAccessException();

            var folders = await folderRepository.GetAllUserFoldersAsync(userId);
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

    public async Task<FolderResponse?> GetAsync(Guid folderId)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId) ?? throw new EmptyReturnException("No folder was retreived");

            if (!userAuthService.UserIsAdmin || userAuthService.UserId != folder.UserId) throw new UnauthorizedAccessException();

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

    public async Task UpdateAsync(UpdateFolderRequest request)
    {
        try
        {
            if (!userAuthService.UserIsAdmin || userAuthService.UserId != request.UserId) throw new UnauthorizedAccessException();

            var folder = await folderRepository.GetAsync(request.Id) ?? throw new EmptyReturnException("No folder found with that Id");

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
