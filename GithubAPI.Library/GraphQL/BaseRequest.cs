using System.Net.Http.Headers;
using GraphQL;

namespace GithubAPI.Library.GraphQL;

public class BaseRequest : CustomHeaderRequest
{
    public BaseRequest(AuthenticationHeaderValue authentication) : base(authentication)
    {
        Query = @"
                query ($orgLogin: String!) {
                  organization(login: $orgLogin) {
                    name
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
        OperationName = "baseRequest";
        Variables = new
        {
            orgLogin = "sunyam-lexicon-2024"
        };
    }

}