using GithubAPI.Library.GraphQL.Types.Interfaces;

namespace GithubAPI.Library.GraphQL.Types;

public class NodeType : INodeType
{
    public string? ID { get; set; }
    public string? Name { get; set; }
}