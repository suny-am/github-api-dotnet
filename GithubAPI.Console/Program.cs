using GithubAPI.Library.GraphQL;
using GithubAPI.Library.GraphQL.Records;

string? ghApiToken;

try
{
    ghApiToken = Environment.GetEnvironmentVariable("GITHUB_ACCESS_TOKEN"); // this needs to be set in your environment when testing
}
catch (Exception ex)
{
    throw new Exception("Could not load token from environment", ex);
}

GraphQLHandler graphQLHandler = new(ghApiToken!);

IEnumerable<Repository>? result = await graphQLHandler.GetRepositoriesBySearch();

Console.WriteLine(result?.Count());