using GithubAPI.Library.GraphQL.Requests;
using GithubAPI.Library.GraphQL.Types;
using GraphQL.Client.Http;

namespace GithubAPI.Library.GraphQL;

public interface IGraphQLHandler {

    public GraphQLHttpClient GraphQLClient { get; }

    public Task<dynamic?> PerformQuery(AuthenticatedRequest request);

}