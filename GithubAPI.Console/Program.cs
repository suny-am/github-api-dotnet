using GithubAPI.Library.GraphQL;
using dotenv.net;

DotEnv.Load();

string? token = Environment.GetEnvironmentVariable("ACCESS_TOKEN"); // this needs to be set in your environment when testing

if (token is null)
{
    Console.WriteLine("could not load token");
    return;
}

var graphqlClient = new GraphQLClient(token!);

await graphqlClient.GetAsync();


/*
Github API docs: 
https://docs.github.com/en/rest?apiVersion=2022-11-28

*** Endpoints to use: *** 

Org repos: 
https://api.github.com/orgs/sunyam-lexicon-2024/repos
Org Pages: 
https://api.github.com/repos/sunyam-lexicon-2024/${REPO}/pages)

*/
