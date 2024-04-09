using System.Net.Http.Headers;

namespace GithubAPI.Library.GraphQL;

public class BaseRequest : CustomHeaderRequest
{
  public BaseRequest(AuthenticationHeaderValue authentication) : base(authentication)
  {

    Query = @"query ($orgLogin: String!, $userLogin: String!) {
              user(login: $userLogin) {
                id
                login
                name
              }      
              organization(login: $orgLogin) {
                name
                repositories(first: 20) {
                  nodes {
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
            }";
    Variables = new
    {
      orgLogin = "sunyam-lexicon-2024",
      userLogin = "suny-am"
    };
  }
}