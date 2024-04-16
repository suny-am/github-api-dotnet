using GithubAPI.Library.GraphQL.Types.Interfaces;

namespace GithubAPI.Library.GraphQL.Types;

public class RepositoryType : NodeType
{
    public string? HomepageURL { get; set; }
    public required string URL { get; set; }
    public DateTime PushedAt { get; set; }
    public long DiskUsage { get; set; }
    public string? Description { get; set; }
    public required ObjectType Object { get; set; }
    public required DefaultBranchRefType DefaultBranchRef { get; set; }
}