namespace Backend.Interfaces;

public interface IFileService
{
    public Task<bool> CreateAsync(DTO.FileDTO fileDTO);
    public Task<DTO.FileDTO?> GetByIdAsync(string fileId);
    public Task<DTO.FileDTO?> GetByNameAsync(string fileName);
    public Task<ICollection<DTO.FileDTO>> GetAllUserFilesAsync(string userId);
    public Task<bool> UpdateAsync(DTO.FileDTO fileDTO);
    public Task<bool> DeleteAsync(string fileId);
}