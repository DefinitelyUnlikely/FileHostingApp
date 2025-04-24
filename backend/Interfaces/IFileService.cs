namespace Backend.Interfaces;

public interface IFileService
{
    public Task<bool> CreateAsync(DTO.FileDTO fileDTO);
    public Task<DTO.FileDTO?> GetByIdAsync(Guid fileId);
    public Task<DTO.FileDTO?> GetByNameAsync(string fileName);
    public Task<ICollection<DTO.FileDTO>> GetAllAsync();
    public Task<bool> UpdateAsync(DTO.FileDTO fileDTO);
    public Task<bool> DeleteAsync(Guid fileId);
}