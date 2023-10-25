namespace TDD
{
  public class DefaultPasswordValidator
  {
    public bool Validate(string password)
    {
      return password.Length >= 8 && password.Length <= 15;
    }
  }
}
