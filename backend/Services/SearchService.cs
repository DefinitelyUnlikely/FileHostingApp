using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class SearchService : ISearchService
{
    public Task<ICollection<FileMeta>> FindFilesByDateAsync(DateTime fromDate, DateTime toDate, bool byCreatedDate = true)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<FileMeta>> FindFilesByTextAsync(string text)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Folder>> FindFolderAsync(string name)
    {
        throw new NotImplementedException();
    }
}
