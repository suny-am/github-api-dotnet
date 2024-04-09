using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using System.Net.Http.Headers;

namespace GithubAPI.Library.GraphQL;

public class CustomHeaderRequest(AuthenticationHeaderValue authentication) : GraphQLHttpRequest
{
    private AuthenticationHeaderValue _authentication = authentication;

    public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, IGraphQLJsonSerializer serializer)
    {
        var r = base.ToHttpRequestMessage(options, serializer);
        r.Headers.Authorization = _authentication;
        return r;
    }
}