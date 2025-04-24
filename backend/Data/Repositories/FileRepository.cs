using Backend.Interfaces;

namespace Backend.Data.Repositories;


public class FileRepository : IFileRepository
{
    /// <summary>Delete the, by EntityFrameWork, tracked file given as an argument.</summary>
    /// <returns>A boolean value indicating if the deletion was successful or not.</returns>
    public Task<bool> DeleteAsync(Models.File file)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that gets and returns all files in the current context.</summary>
    /// <returns>An ICollection of all file entity objects.</returns>
    public Task<ICollection<Models.File>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that gets and returns a file by specified Id.</summary>
    /// <returns>A single file entity object.</returns>
    public Task<Models.File> GetAsync(Guid fileId)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that gets and returns a file by specified name.</summary>
    /// <returns>A single file entity object.</returns>
    public Task<Models.File> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that takes a file entity object and saves it to the current context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public Task<bool> SaveAsync(Models.File file)
    {
        throw new NotImplementedException();
    }

    /// <summary>A method that takes a tracked file entity object and saves it to the context.</summary>
    /// <returns>A boolean value indicating if the save was successful or not.</returns>
    public Task<bool> UpdateAsync(Models.File file)
    {
        throw new NotImplementedException();
    }
}