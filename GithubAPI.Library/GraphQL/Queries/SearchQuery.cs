using System.Net.Http.Headers;
using GithubAPI.Library.GraphQL.Queries.Fragments;

namespace GithubAPI.Library.GraphQL;

public class SearchQuery : CustomHeaderRequest
{
  public SearchQuery(AuthenticationHeaderValue authentication) : base(authentication)
  {
    Query = @"query ($queryString: String!) {
              search(query: $queryString, type: REPOSITORY, first: 100) {
                repositoryCount
                edges {
                  node {" 
                  + RepositoryFragment.Name +
                 @"}
                }
              }
            }" + RepositoryFragment.Value;
    Variables = new
    {
      queryString = "org:sunyam-lexicon-2024"
    };
  }
}