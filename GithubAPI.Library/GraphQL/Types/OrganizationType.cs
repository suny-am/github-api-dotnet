namespace GithubAPI.Library.GraphQL.Types;

public class OrganizationType
{
    public string? Name { get; set; }
    public List<RepositoryType>? Repositories { get; set; }
}