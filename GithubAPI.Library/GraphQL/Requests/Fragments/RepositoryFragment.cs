namespace GithubAPI.Library.GraphQL.Requests.Fragments;

public class RepositoryFragment : BaseFragment
{

  public RepositoryFragment()
  {
    Name = "...repoFragment";
    Value = @"fragment repoFragment on Repository {
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
                                        ";

  }
}