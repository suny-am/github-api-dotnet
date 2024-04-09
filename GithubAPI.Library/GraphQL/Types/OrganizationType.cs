namespace GithubAPI.Library.GraphQL.Types;

public class OrganizationType
{
    public string? Name { get; set; }
    public RepositoryListType? Repositories { get; set; }
}