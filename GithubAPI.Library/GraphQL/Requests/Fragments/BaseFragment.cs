namespace GithubAPI.Library.GraphQL.Requests.Fragments;

public class BaseFragment(string? name = null, string? value = null) : IFragment
{
  private string _name = name!;
  private string _value = value!;

  public string Name { get => _name; set => _name = value; }
  public string Value { get => _value; set => _value = value; }
}