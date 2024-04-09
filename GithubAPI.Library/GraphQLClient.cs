namespace GithubAPI.Library;

using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GraphQLClient(string apiToken)
{
    private readonly string _apiToken = apiToken;
    private readonly GraphQLHttpClient _graphQlHttpClient = new("https://api.github.com/graphql", new NewtonsoftJsonSerializer());

    public async Task GetAsync()
    {
        string query = @"query ($orgLogin: String!) {
  organization(login: $orgLogin) {
    repositories(first: 20) {
      nodes {
        defaultBranchRef {
          target {
            ... on Commit {
              history {
                totalCount
              }
            }
          }
        }
      }
    }
  }
}
                ";

        var request = new GraphQLCustomHeaderRequest(
            new AuthenticationHeaderValue("bearer", _apiToken.Trim()))
        {
            Query = query,
            Variables = new
            {
                orgLogin = "sunyam-lexicon-2024",
                userLogin = "suny-am"
            }
        };

        var response = await _graphQlHttpClient.SendQueryAsync<JObject>(request);

        JObject data = response.Data;

        var list = data["organization"]!["repositories"]!["nodes"]!.AsJEnumerable();

        foreach (var item in list)
        {
            Console.WriteLine(item["defaultBranchRef"]!["target"]!["history"]!["totalCount"]);
        }
    }
}
