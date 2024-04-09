namespace GithubAPI.Library;
using System.Net.Http.Headers;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

public class GraphQLCustomHeaderRequest(AuthenticationHeaderValue authentication) : GraphQLHttpRequest
{
    private AuthenticationHeaderValue _authentication = authentication;
    public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, IGraphQLJsonSerializer serializer)
    {
        var r = base.ToHttpRequestMessage(options, serializer);
        r.Headers.Authorization = _authentication;
        return r;
    }
}