namespace Backend.Interfaces;

public interface IFileService
{
    public Task<bool> CreateAsync(DTO.FileDTO fileDTO);
    public Task<DTO.FileDTO?> GetAsync(Guid fileId);
    public Task<ICollection<DTO.FileDTO>> GetAllAsync();
    public Task<bool> UpdateAsync(DTO.FileDTO fileDTO);
    public Task<bool> DeleteAsync(Guid fileId);
}