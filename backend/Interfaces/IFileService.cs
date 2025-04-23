namespace Backend.Interfaces;

// For create and update, we'll send a file DTO. 
// As I haven't made a class for it yet, Im just leaving this comment.
public interface IFileService
{
    public Task<bool> CreateAsync();
    public Task<Models.File> GetAsync(Guid fileId);
    public Task<ICollection<Models.File>> GetAllAsync();
    public Task<bool> UpdateAsync();
    public Task<bool> DeleteAsync(Guid fileId);
}