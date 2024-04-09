using System.Net.Http.Headers;

namespace GithubAPI.Library.GraphQL;

public class SearchRequest : CustomHeaderRequest
{
  public SearchRequest(AuthenticationHeaderValue authentication) : base(authentication)
  {

    Query = @"query ($queryString: String!) {
              search(query: $queryString, type: REPOSITORY, first: 100) {
                repositoryCount
                edges {
                  node {
                    ... on Repository {
                      name
                      url
                      homepageUrl
                      pushedAt
                      defaultBranchRef {
                        name
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
            }";
    Variables = new
    {
      queryString = "org:sunyam-lexicon-2024"
    };
  }
}