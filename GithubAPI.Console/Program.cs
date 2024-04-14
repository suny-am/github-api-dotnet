using GithubAPI.Library.GraphQL;
using GithubAPI.Library.GraphQL.Records;

string? ghApiToken;

HttpClient tokenClient = new();

try
{
    string endpoint = Environment.GetEnvironmentVariable("GITHUB_TOKEN_ENDPOINT")!;
    ghApiToken = await tokenClient.GetStringAsync(endpoint); // this needs to be set in your environment when testing
}
catch (Exception ex)
{
    throw new Exception("Could not get github access token", ex);
}

GraphQLHandler graphQLHandler = new(ghApiToken!.Trim());

IEnumerable<Repository>? result = await graphQLHandler.GetRepositoriesBySearch();

Console.WriteLine(result?.Count());