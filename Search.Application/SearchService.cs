// Application Layer

using Shared;

public class SearchService
{
    private readonly ISearchPlugin _searchPlugin;

    public SearchService(ISearchPlugin searchPlugin)
    {
        _searchPlugin = searchPlugin;
    }

    public string PerformSearch(string query)
    {
        if (_searchPlugin == null)
        {
            throw new InvalidOperationException("No plugin is loaded.");
        }

        return _searchPlugin.Search(query);
    }
}