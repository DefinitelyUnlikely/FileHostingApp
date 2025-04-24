using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class SearchService : ISearchService
{
    public Task<ICollection<Models.File>> FindFilesByDateAsync(DateTime fromDate, DateTime toDate, bool byCreatedDate = true)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Models.File>> FindFilesByTextAsync(string text)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Folder>> FindFolderAsync(string name)
    {
        throw new NotImplementedException();
    }
}
