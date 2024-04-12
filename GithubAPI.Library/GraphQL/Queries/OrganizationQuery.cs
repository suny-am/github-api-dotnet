using System.Net.Http.Headers;
using GithubAPI.Library.GraphQL.Queries.Fragments;

namespace GithubAPI.Library.GraphQL.Queries;

public class OrganizationQuery : CustomHeaderRequest
{
  public OrganizationQuery(AuthenticationHeaderValue authentication) : base(authentication)
  {
    Query = @"query($orgLogin:String!){
              organization(login: $orgLogin) {
                name
                repositories(first: 20) {
                  nodes {"
                  + RepositoryFragment.Name +
                  @"}
                }
              }
            }
            " + RepositoryFragment.Value;
    Variables = new
    {
      orgLogin = "sunyam-lexicon-2024",
    };
  }
}