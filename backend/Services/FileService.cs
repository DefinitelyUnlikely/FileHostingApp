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
            // Validate that all required data exists in the DTO
            if (fileDTO.Name is null || fileDTO.Extension is null || fileDTO.UserId is null || fileDTO.FileData is null)
            {
                throw new ArgumentException("Not all required data has been provided.");
            }

            // Might change these touse constructors instead and removing the required keyword
            // from the properties. Will have to see what I find gives most clarity to the reader of the code.
            var fileInfo = new FileMeta
            {
                Id = Guid.NewGuid(),
                Name = fileDTO.Name,
                Extension = fileDTO.Extension,
                CreatedAt = DateTime.UtcNow,
                UserId = fileDTO.UserId
            };
            var fileData = new FileData
            {
                Id = Guid.NewGuid(),
                FileId = fileInfo.Id,
                Bytes = fileDTO.FileData
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

    public async Task<ICollection<FileDTO>> GetAllUserFilesAsync(string userId)
    {
        try
        {
            var files = (List<FileMeta>)await fileRepository.GetAllUserFilesAsync(userId);

            if (files.Count == 0) throw new EmptyReturnException("The returned list or object is empty.");

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

    public async Task<FileDTO?> GetByIdAsync(Guid fileId)
    {
        try
        {
            var file = await fileRepository.GetByIdAsync(fileId, true) ?? throw new EmptyReturnException("No file with that Id was found.");

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was not found or could not be included");
            }

            return new FileDTO
            {
                Id = file.Id,
                Name = file.Name,
                Extension = file.Extension,
                FileData = file.FileData.Bytes,
                CreatedAt = file.CreatedAt,
                UpdatedAt = file.UpdatedAt,
                FolderId = file.FolderId,
                UserId = file.UserId
            };
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task<FileDTO?> GetByNameAsync(string fileName)
    {
        try
        {
            var file = await fileRepository.GetByNameAsync(fileName, true) ?? throw new EmptyReturnException("No file with that name was found.");

            if (file.FileData is null)
            {
                throw new Exception("the corresponding filedata was not found or could not be included");
            }

            return new FileDTO
            {
                Id = file.Id,
                Name = file.Name,
                Extension = file.Extension,
                FileData = file.FileData.Bytes,
                CreatedAt = file.CreatedAt,
                UpdatedAt = file.UpdatedAt,
                FolderId = file.FolderId,
                UserId = file.UserId
            };
        }
        catch (Exception e)
        {
            logger.LogError("Message: {Message} \n StackTrace: {StackTrace}", e.Message, e.StackTrace);
            throw;
        }
    }

    public async Task UpdateAsync(FileDTO DTO)
    {
        try
        {
            if (!await fileRepository.UpdateAsync()) throw new NoChangesSavedException("File could not be updated.");
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
