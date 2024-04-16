using GithubAPI.Library.GraphQL;
using GithubAPI.Library.GraphQL.Requests;
using GithubAPI.Library.GraphQL.Requests.Fragments;
using GithubAPI.Library.GraphQL.Types;

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

GraphQLHandler graphQLHandler = new(ghApiToken!);

RepositoryFragment repoFragment = new();

// Example query 1

string searchQuery = @"query ($queryString: String! $count: Int!, $type: SearchType!) {
                        search(query: $queryString, type: $type, first: $count) {
                repositoryCount
                edges {
                  node {"
                  + repoFragment.Name +
                 @"}
                }
              }
            }" + repoFragment.Value;

var variables = new
{
  queryString = "org:sunyam-lexicon-2024",
  count = 100,
  type = "REPOSITORY"
};

var request1 = new AuthenticatedRequest(searchQuery, variables);
ResponseType? result1;
IEnumerable<RepositoryType?> repositories1;
string message1 = "success";

try
{
  result1 = await graphQLHandler.PerformQuery(request1) ?? throw new Exception("failed");
  repositories1 = (result1!.Search?.Edges?.Select(e => e.Node)) ?? throw new Exception("failed");
  Console.WriteLine("Repo count: " + repositories1.Count());
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}

Console.WriteLine(message1);

Console.Read();

// Example query 2

RepositoryConnectionFragment repoConnectionFragment = new();

string orgQuery = @"query ($orgLogin: String! $count: Int!) {
                organization(login: $orgLogin) {
                  repositories(first: $count) {
                    ... on RepositoryConnection {"
                     + repoConnectionFragment.Name +
                    @"}
                  }
                }
              }" + repoConnectionFragment.Value;
var variables2 = new
{
  orgLogin = "sunyam-lexicon-2024",
  count = 100,
};

var request2 = new AuthenticatedRequest(orgQuery, variables2);
ResponseType? result2;
List<NodeType>? repositories2;

string message2 = "success";
try
{
  result2 = await graphQLHandler.PerformQuery(request2) ?? throw new Exception("failed");
  repositories2 = (result2!.Organization?.Repositories?.Nodes) ?? throw new Exception("failed");
  Console.WriteLine("Repo count: " + repositories2.Count);
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}

Console.WriteLine(message2);