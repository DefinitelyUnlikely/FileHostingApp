namespace Backend.Interfaces;

public interface IFileService
{
    public Task CreateAsync(DTO.FileDTO fileDTO);
    public Task<DTO.FileDTO?> GetByIdAsync(Guid fileId);
    public Task<DTO.FileDTO?> GetByNameAsync(string fileName);
    public Task<ICollection<DTO.FileDTO>> GetAllUserFilesAsync(string userId);
    public Task UpdateAsync(DTO.FileDTO fileDTO);
    public Task DeleteAsync(Guid fileId);
}