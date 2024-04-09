using GithubAPI.Library.GraphQL;

var tokenClient = new HttpClient();

var tokenResponse = await tokenClient.GetAsync("https://gh-api-token-provider.azurewebsites.net/api/token");

var token = await tokenResponse.Content.ReadAsStringAsync();

var graphqlClient = new GraphQLClient(token.Trim());

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
