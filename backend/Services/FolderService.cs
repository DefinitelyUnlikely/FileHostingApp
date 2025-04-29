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
                throw new MissingRequiredDataException("Not all required data has been supplied.");
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

            if (!await folderRepository.AddAsync(folder)) throw new NoChangesSavedException("Folder could not be added");

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
