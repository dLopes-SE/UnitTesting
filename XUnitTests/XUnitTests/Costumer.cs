namespace XUnitTests
{
  public class Costumer
  {
    public string Name => "Aref";
    public int Age => 35;

    public void GetAnException() { throw new ArgumentException("Hello"); }
  }
}
