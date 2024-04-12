namespace GithubAPI.Library.GraphQL.Types;

public class NodeType
{
    public required string ID   { get; set; }
    public required string Name { get; set; }
    public string? HomepageURL { get; set; }
    public required string URL { get; set; }
    public DateTime PushedAt { get; set; }
    public long DiskUsage { get; set; }
    public string? Description { get; set; }
    public required ObjectType Object { get; set; }
    public required DefaultBranchRefType DefaultBranchRef { get; set; }
}