using GithubAPI.Library.GraphQL.Types;

namespace GithubAPI.Library.GraphQL;

public class BaseResponse
{
    public OrganizationType? Organization { get; set; }
}