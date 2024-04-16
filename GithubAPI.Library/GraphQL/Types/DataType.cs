namespace GithubAPI.Library.GraphQL.Types;

public class DataType {
    public int? RepositoryCount { get; set; }
    public List<EdgeType>? Edges { get; set; }
}