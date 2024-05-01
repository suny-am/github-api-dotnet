using System.Net.Http.Headers;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GithubAPI.Library.GraphQL.Types;
using GithubAPI.Library.GraphQL.Requests;

namespace GithubAPI.Library.GraphQL;

public class GraphQLHandler(string apiToken) : IGraphQLHandler
{
  private readonly AuthenticationHeaderValue _auth = new("bearer", apiToken);
  private readonly GraphQLHttpClient _client = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

  public GraphQLHttpClient GraphQLClient => _client;

  public async Task<dynamic?> PerformQuery(AuthenticatedRequest graphQLRequest)
  {
    graphQLRequest.Authentication = _auth;

    var response = await _client.SendQueryAsync<ResponseType>(graphQLRequest);

    if (response.Errors is not null)
    {
      throw new GraphQLHttpRequestException(response.AsGraphQLHttpResponse().StatusCode,
                                            response.AsGraphQLHttpResponse().ResponseHeaders,
                                            "could not perform query");
    }
    return response.Data;
  }
}