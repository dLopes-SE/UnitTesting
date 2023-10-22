namespace XUnitTests.Tests
{
  public static class TestDataShare
  {
    public static IEnumerable<object[]> IsOddOrEvenData
    {
      get
      {
        yield return new object[] { 1, true };
        yield return new object[] { 2, false };
      }
    }
  }
}
