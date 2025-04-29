using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FolderService(ILogger logger, IFolderRepository folderRepository) : IFolderService
{
    public async Task CreateAsync(FolderRequest request)
    {
        try
        {

            //Validate DTO
            if (request.Name is null || request.UserId is null)
            {
                throw new ArgumentException("Not all required data has been supplied.");
            }

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
        catch (ArgumentException e)
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

    public async Task DeleteAsync(Guid folderId)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId) ?? throw new EmptyReturnException("No folder with that Id was found.");
            if (!await folderRepository.DeleteAsync(folder)) throw new NoChangesSavedException("No folder has been deleted.");
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

    public async Task<ICollection<FolderResponse>> GetAllUserFoldersAsync(string userId)
    {
        try
        {
            var folders = await folderRepository.GetAllUserFoldersAsync(userId);
            if (folders is null || folders.Count == 0) throw new EmptyReturnException("No folders where found for this user");

            List<FolderResponse> returnFolders = [];
            foreach (var folder in folders)
            {
                returnFolders.Add(FolderResponse.FromModel(folder));
            }

            return returnFolders;

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
            return FolderResponse.FromModel(folder);
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

    public async Task UpdateAsync(FolderRequest request)
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
}
