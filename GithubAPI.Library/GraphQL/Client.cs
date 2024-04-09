using System.Net.Http.Headers;
using GithubAPI.Library.GraphQL.Types;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using SharpConsole;
using System.Globalization;

namespace GithubAPI.Library.GraphQL;

public class GraphQLClient(string apiToken)
{
  private readonly IO _io = IO.Instance;
  private readonly string _apiToken = apiToken;
  private readonly GraphQLHttpClient _graphQlHttpClient = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

  public async Task GetAsync()
  {

    var auth = new AuthenticationHeaderValue("bearer", _apiToken);
    // var baseRequest = new BaseRequest(auth);

    // var response = await _graphQlHttpClient.SendQueryAsync(
    //   baseRequest, () => new
    //   {
    //     user = new UserType(),
    //     organization = new OrganizationType()
    //   });

    // var organization = response.Data.organization;

    // var repos = organization!.Repositories!.Nodes!;

    // foreach (var r in repos)
    // {
    //   string githubPagesLink = r.HomepageURL?.Length > 0 ? r.HomepageURL : "No Github Pages";
    //   int commitCount = r.DefaultBranchRef?.Target?.History?.TotalCount ?? 0;
    //   string pushedAtTime = Convert.ToDateTime(r.PushedAt!).ToString("MMM. dd, yyyy HH:mm:ss");
    //   _io.WriteEncoded(
    //     $"[blue]Repository:[blue] [green]{r.Name}[green]" +
    //     Environment.NewLine +
    //     $"[blue]Github Link:[blue] [green]{r.URL}[green]" +
    //     Environment.NewLine +
    //     $"[blue]Branch:[blue] [green]{r.DefaultBranchRef!.Name}[green]" +
    //     Environment.NewLine +
    //     $"[blue]Last pushed:[blue] [green]{pushedAtTime}[green]" +
    //     Environment.NewLine +
    //     $"[blue]Commit count:[blue] [green]{commitCount}[green]" +
    //     Environment.NewLine +
    //     $"[blue]Github Pages:[blue] [green]{githubPagesLink}[green]" +
    //     Environment.NewLine +
    //     Environment.NewLine
    //   );
    // }

    // var user = response.Data.user;

    // _io.Write(user.Name, newline: true);
    // _io.Write(user.Login, newline: true);
    // _io.Write(user.ID, newline: true);

    var searchRequest = new SearchRequest(auth);

    var response2 = await _graphQlHttpClient.SendQueryAsync(
         searchRequest, () => new
         {
           search = new SearchType(),
         });

    var searchResult = response2.Data.search;

    var edges = searchResult.Edges;
    if (edges is null) return;

    foreach (var e in edges)
    {
      var n = e.Node;
      if (n is null) continue;
      string githubPagesLink = n.HomepageURL?.Length > 0 ? n.HomepageURL : "No Github Pages";
      int commitCount = n.DefaultBranchRef?.Target?.History?.TotalCount ?? 0;
      string pushedAtTime = Convert.ToDateTime(n.PushedAt!).ToString("MMM. dd, yyyy HH:mm:ss");
      _io.WriteEncoded(
        $"[blue]Repository:[blue] [green]{n.Name}[green]" +
        Environment.NewLine +
        $"[blue]Github Link:[blue] [green]{n.URL}[green]" +
        Environment.NewLine +
        $"[blue]Branch:[blue] [green]{n.DefaultBranchRef!.Name}[green]" +
        Environment.NewLine +
        $"[blue]Last pushed:[blue] [green]{pushedAtTime}[green]" +
        Environment.NewLine +
        $"[blue]Commit count:[blue] [green]{commitCount}[green]" +
        Environment.NewLine +
        $"[blue]Github Pages:[blue] [green]{githubPagesLink}[green]" +
        Environment.NewLine +
        Environment.NewLine
      );
    }


  }
}