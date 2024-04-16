# Github API .NET Library

## Description

A .NET Library for communicating with the Github API (only GraphQL is supported for now).

## Features

- A generic request client that enables authorized queries
- preconfigured extendable query result types, derived from the Github GraphQL API Schema:

```
    # Github GraphQL API schema introspection
query {
  __schema {
    types {
      name
      possibleTypes {
        ...
      }
    }
  }
}
```

## Notes

The preconfigured types can be, and are encouraged to be extended to suit your needs.
This is because the scope of the Github API makes it unfeasible to maintain preconfigured types
for each type in the schema. View the existing Types as inspiration. The inheritance structure in C#
makes extending and/or overriding a Type trivial.

Due to how GraphQL response namespaces work the responsetype has to match the request query:

```
# Example query
RepositoryConnectionFragment repoConnectionFragment = new();

string repoQuery = @"query ($orgLogin: String! $count: Int!) {
                organization(login: $orgLogin) {
                  repositories(first: $count) {
                    ... on RepositoryConnection {
                      nodes {
                        id
                        name
                      }
                    }
                  }
                }
              }
              
var variables2 = new
{
  orgLogin = "someOrgLogin",
  count = 100,
};

var request = new AuthenticatedRequest(repoQuery, variables2);

ResponseType? result = await graphQLHandler.PerformQuery(request);

# Handle Exceptions
if (result! is null)
{
  ...
}

# match the expected result Type to the request query
RepositoryListType? repositories = result2!.Organization?.Repositories;

# consume the result
Console.WriteLine(repositories.Nodes.Count());

```

## Testing

The _GithubAPI.Console_ project can be used to test functionality locally

## Resources

- [Github REST API Docs](https://docs.github.com/rest)
- [Github GraphQL API Docs](https://docs.github.com/graphql)
- [Github GraphQL API Explorer](https://docs.github.com/en/graphql/overview/explorer)
- [.NET GraphQL docs](https://graphql-dotnet.github.io/docs/getting-started)
- [.NET GraphQL Client](https://github.com/graphql-dotnet/graphql-client)

## Contact

[visualarea.1@gmail.com](mailto:visualarea.1@gmail.com)
