using System.Net.Http.Headers;
using GithubAPI.Library.GraphQL.Types;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using GithubAPI.Library.GraphQL.Queries;
using GithubAPI.Library.GraphQL.Records;
using GraphQL;

namespace GithubAPI.Library.GraphQL;

public class GraphQLHandler(string apiToken)
{
  private readonly AuthenticationHeaderValue _auth = new("bearer", apiToken);
  private readonly GraphQLHttpClient _graphQlHttpClient = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

  public async Task<IEnumerable<NodeType>?> GetDiskUsageByQuery()
  {
    var orgQuery = new OrganizationQuery(_auth);
    var response = await _graphQlHttpClient.SendQueryAsync(
      orgQuery, () => new
      {
        user = new UserType(),
        organization = new OrganizationType()
      });

    return response.Data.organization.Repositories!.Nodes!;
  }

  public async Task<IEnumerable<Repository>?> GetDiskUsageBySearch()
  {
    GraphQLRequest searchQuery = new SearchQuery(_auth);
    GraphQLResponse<SearchResponseType> response = await _graphQlHttpClient.SendQueryAsync(
         searchQuery, () => new SearchResponseType()
         {
           search = new SearchType(),
         });

    return CreateRepositoryRecords(response);
  }

  private static IEnumerable<Repository>? CreateRepositoryRecords(GraphQLResponse<SearchResponseType> searchResponse)
  {
    var repositories = searchResponse.Data.search
                                          .Edges?
                                          // filter out org link repository
                                          .Where(e => e.Node!.Name != ".github")
                                          .Select(e => e.Node!)
                                          .Select(n => new Repository
                                          (id: n.ID,
                                           name: n.Name,
                                           homepageUrl: n.HomepageURL ?? "",
                                           url: n.URL,
                                           pushedAt: n.PushedAt,
                                           diskUsage: n.DiskUsage,
                                           commitTotal: n.DefaultBranchRef!
                                                          .Target!
                                                          .History!
                                                          .TotalCount,
                                           description: n.Description ?? ""
                                          ));
    return repositories;
  }
}