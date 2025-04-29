using Backend.DTO;
using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class FolderService(ILogger logger, IFolderRepository folderRepository) : IFolderService
{
    public async Task CreateAsync(FolderDTO folderDTO)
    {
        try
        {

            //Validate DTO
            if (folderDTO.Name is null || folderDTO.UserId is null)
            {
                throw new ArgumentException("Not all required data has been supplied.");
            }

            var folder = new Folder
            {
                Id = Guid.NewGuid(),
                Name = folderDTO.Name,
                ParentFolderId = folderDTO.ParentFolderId,
                UserId = folderDTO.UserId,
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

    public async Task<ICollection<FolderDTO>> GetAllUserFoldersAsync(string userId)
    {
        try
        {
            var folders = await folderRepository.GetAllUserFoldersAsync(userId);
            if (folders is null || folders.Count == 0) throw new EmptyReturnException("No folders where found for this user");

            List<FolderDTO> returnFolders = [];
            foreach (var folder in folders)
            {
                returnFolders.Add(
                    new FolderDTO
                    {
                        Id = folder.Id,
                        Name = folder.Name,
                        ParentFolderId = folder.ParentFolderId,
                        ParentFolder = folder.ParentFolder,
                        SubFolders = folder.SubFolders,
                        UserId = folder.UserId,
                    }
                    );
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

    public async Task<FolderDTO?> GetAsync(Guid folderId)
    {
        try
        {
            var folder = await folderRepository.GetAsync(folderId) ?? throw new EmptyReturnException("No folder was retreived");
            return new FolderDTO
            {
                Id = folder.Id,
                Name = folder.Name,
                ParentFolderId = folder.ParentFolderId,
                ParentFolder = folder.ParentFolder,
                SubFolders = folder.SubFolders,
                UserId = folder.UserId,
            };
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

    public async Task UpdateAsync(FolderDTO folderDTO)
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
