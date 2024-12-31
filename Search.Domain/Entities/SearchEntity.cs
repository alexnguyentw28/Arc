namespace Search.Domain.Entities;

public class SearchEntity
{
    public string Id { get; set; }
    public string IndexName { get; set; }
    public string Name { get; set; }
    public IDictionary<string, object> Attributes { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
}