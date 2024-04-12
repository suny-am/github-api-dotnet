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

if (result is null)
{
    io.Write("no data found", newline: true);
}
else
{
    try
    {
        CosmosDbHandler cosmosDbHandler = new();
        await cosmosDbHandler.LoadDatabase();

        foreach (var repo in result)
        {
            io.Write($"Creating entry for repository {repo.name}...", newline: true);
            await cosmosDbHandler.Create(repo);
            io.WriteEncoded($"[green]{repo.name} inserted successfully into container![green]{Environment.NewLine}");
        }
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
}
