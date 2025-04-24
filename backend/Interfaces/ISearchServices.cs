namespace Backend.Interfaces;

public interface ISearchService
{
    public Task<ICollection<Models.File>> FindFilesByTextAsync(string text);
    public Task<ICollection<Models.File>> FindFilesByDateAsync(DateTime fromDate, DateTime toDate, bool byCreatedDate = true);
    public Task<ICollection<Models.Folder>> FindFolderAsync(string name);
}