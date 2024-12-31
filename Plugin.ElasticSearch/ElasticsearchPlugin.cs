using Shared;

namespace Plugin.ElasticSearch;

public class ElasticsearchPlugin : ISearchPlugin
{
    public string Name { get; }
    public void Initialize(string connectionString)
    {
        throw new NotImplementedException();
    }

    public string Search(string query)
    {
        throw new NotImplementedException();
    }
}