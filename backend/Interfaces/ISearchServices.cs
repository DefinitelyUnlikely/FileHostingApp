namespace Backend.Interfaces;

public interface ISearchService
{
    public Task<ICollection<FileInfo>> FindFilesByTextAsync(string text);
    public Task<ICollection<FileInfo>> FindFilesByDateAsync(DateTime fromDate, DateTime toDate, bool byCreatedDate = true);
    public Task<ICollection<Models.Folder>> FindFolderAsync(string name);
}