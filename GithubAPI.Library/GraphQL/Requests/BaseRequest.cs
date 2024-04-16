using System.Net.Http.Headers;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace GithubAPI.Library.GraphQL.Requests;


public class AuthenticatedRequest(
                        string query,
                        object? variables,
                        string? operationName = null
                        ) : GraphQLHttpRequest(query, variables, operationName)
{
    private AuthenticationHeaderValue? _authentication = null;

    public AuthenticationHeaderValue? Authentication { get => _authentication; set => _authentication = value; }

    public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, IGraphQLJsonSerializer serializer)
    {
        var r = base.ToHttpRequestMessage(options, serializer);
        r.Headers.Authorization = _authentication;
        return r;
    }
}