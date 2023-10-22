namespace XUnitTests
{
  public class DataDriven
  {
    public List<int> IntCollection { get; set; }

    public DataDriven()
    {
      Random random = new();
      IntCollection = new List<int>();
      for (int i = 0; i < 10; i++)
        IntCollection.Add(random.Next(10));
    }

    public bool IsOdd(int value) { return value % 2 == 1;}
  }
}
