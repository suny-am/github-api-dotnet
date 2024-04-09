using System.Net.Http.Headers;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;

namespace GithubAPI.Library.GraphQL;

public class GraphQLClient(string apiToken)
{
  private readonly string _apiToken = apiToken;
  private readonly GraphQLHttpClient _graphQlHttpClient = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

  public async Task GetAsync()
  {
    var request2 = new BaseRequest(new AuthenticationHeaderValue("bearer", _apiToken));

    Console.WriteLine(request2.GetType());

    var response = await _graphQlHttpClient.SendQueryAsync<JObject>(request2);

    JObject data = response.Data;

    var list = data["organization"]!["repositories"]!["nodes"]!.AsJEnumerable();

    foreach (var item in list)
    {
      Console.WriteLine(item["defaultBranchRef"]!["target"]!["history"]!["totalCount"]);
    }
  }
}