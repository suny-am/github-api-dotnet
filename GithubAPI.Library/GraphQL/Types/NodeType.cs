namespace GithubAPI.Library.GraphQL.Types;

public class NodeType
{
    public string? Name { get; set; }
    public string? HomepageURL { get; set; }
    public string? URL { get; set; }
    public string? PushedAt { get; set; }
    public DefaultBranchRefType? DefaultBranchRef { get; set; }
}