using Backend.Models;

namespace Backend.Interfaces;

public interface ISearchService
{
    public Task<ICollection<FileMeta>> FindFilesByTextAsync(string text);
    public Task<ICollection<FileMeta>> FindFilesByDateAsync(DateTime fromDate, DateTime toDate, bool byCreatedDate = true);
    public Task<ICollection<Folder>> FindFolderAsync(string name);
}