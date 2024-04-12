using GithubAPI.Library.GraphQL;
using GithubAPI.Library.GraphQL.Records;
using GithubAPI.Library.Azure.Cosmos;
using SharpConsole;

IO io = IO.Instance;

string? ghApiToken;

try
{
    ghApiToken = Environment.GetEnvironmentVariable("GITHUB_ACCESS_TOKEN"); // this needs to be set in your environment when testing
}
catch (Exception ex)
{
    throw new Exception("Could not load token from environment", ex);
}

var graphQLHandler = new GraphQLHandler(ghApiToken!);

IEnumerable<Repository>? result = await graphQLHandler.GetDiskUsageBySearch();

io.Write(result.Count(), newline: true)