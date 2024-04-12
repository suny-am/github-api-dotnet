namespace GithubAPI.Library.GraphQL.Records;

public record Repository(
#pragma warning disable IDE1006 // Naming Styles
    string id,
    string name,
    string homepageUrl,
    string url,
    DateTime pushedAt,
    long diskUsage,
    int commitTotal,
    string description
#pragma warning restore IDE1006 // Naming Styles
);


