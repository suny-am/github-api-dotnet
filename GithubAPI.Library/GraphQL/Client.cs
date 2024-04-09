using System.Net.Http.Headers;
using GithubAPI.Library.GraphQL.Types;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json.Linq;

namespace GithubAPI.Library.GraphQL;

public class GraphQLClient(string apiToken)
{
  private readonly string _apiToken = apiToken;
  private readonly GraphQLHttpClient _graphQlHttpClient = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

  public async Task GetAsync()
  {
    var request = new BaseRequest(new AuthenticationHeaderValue("Bearer", _apiToken));

    var response = await _graphQlHttpClient.SendQueryAsync<JObject>(request);

    Console.WriteLine(response.Data);

  }
}
