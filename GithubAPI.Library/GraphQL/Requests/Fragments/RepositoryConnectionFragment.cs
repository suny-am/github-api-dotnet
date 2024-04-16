namespace GithubAPI.Library.GraphQL.Requests.Fragments;

public class RepositoryConnectionFragment : BaseFragment
{

  public RepositoryConnectionFragment()
  {
    Name = "...repoConnectionFragment";
    Value = @"fragment repoConnectionFragment on RepositoryConnection {
                                          nodes {
                                          id
                                          name
                                          url
                                          homepageUrl
                                          pushedAt
                                          diskUsage
                                          description
                                          defaultBranchRef {
                                            name
                                            target {
                                              ... on Commit {
                                                oid
                                                history {
                                                  totalCount
                                                }
                                              }
                                            }
                                          }
                                        }
                                      }
                                        ";
  }
}