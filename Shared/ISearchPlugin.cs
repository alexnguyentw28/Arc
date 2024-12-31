namespace Shared;

public interface ISearchPlugin
{
    string Name { get; }
    void Initialize(string connectionString);
    string Search(string query);
}