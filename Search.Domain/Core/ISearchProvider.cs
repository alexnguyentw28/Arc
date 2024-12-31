namespace Search.Domain.Core;

public interface ISearchProvider
{
    Task IndexDocumentAsync<T>(string indexName, string documentId, T document);
    Task DeleteDocumentAsync(string indexName, string documentId);
    Task<IEnumerable<T>> SearchAsync<T>(string indexName, string query, IDictionary<string, string> filters);
}