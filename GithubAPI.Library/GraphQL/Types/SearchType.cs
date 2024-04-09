namespace GithubAPI.Library.GraphQL.Types;

public class SearchType {
    public int RepositoryCount { get; set; }
    public List<EdgeType>? Edges { get; set; }
}