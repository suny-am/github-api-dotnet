namespace GithubAPI.Library.GraphQL.Queries.Fragments;

public static class RepositoryFragment
{
  public static readonly string Name = "...repoFragment";
    public static readonly string Value = @"fragment repoFragment on Repository {
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