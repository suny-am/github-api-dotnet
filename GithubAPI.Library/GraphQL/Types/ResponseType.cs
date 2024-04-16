namespace GithubAPI.Library.GraphQL.Types;

public class ResponseType
{
  public SearchType? Search { get; set; }
  public UserType? User { get; set; }
  public RepositoryType? Repository { get; set; }
  public RepositoryListType? Repositories { get; set; }
  public OrganizationType? Organization { get; set; }
  public EdgeType? Edge { get; set; }
  public TargetType? Target { get; set; }
  public HistoryType? History { get; set; }
  public ObjectType? Object { get; set; }
  public EntryType? Entry { get; set; }
  public DefaultBranchRefType? DefaultBranchRef { get; set; }
}