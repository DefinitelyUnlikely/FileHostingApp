namespace Backend.Interfaces;

public interface IFileService
{
    public Task<bool> CreateAsync(DTO.FileDTO fileDTO);
    public Task<Models.File?> GetAsync(Guid fileId);
    public Task<ICollection<Models.File>> GetAllAsync();
    public Task<bool> UpdateAsync(DTO.FileDTO fileDTO);
    public Task<bool> DeleteAsync(Guid fileId);
}