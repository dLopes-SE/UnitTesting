namespace XUnitTests
{
  public class Customer
  {
    public string Name => "Aref";
    public int Age => 35;

    public void GetAnException() { throw new ArgumentException("Hello"); }
    public string GetFullName(string firstName, string lastName)
    {
      return $"{firstName} {lastName}";
    }
  }
}
