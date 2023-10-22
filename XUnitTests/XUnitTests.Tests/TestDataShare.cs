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

    public static IEnumerable<object[]> IsOddOrEvenExternalData
    {
      get
      {
        var allLines = File.ReadAllLines("C:\\Users\\dlopes\\Desktop\\Projects\\UnitTesting\\XUnitTests\\XUnitTests.Tests\\IsOddOrEvenTestData.txt");
        return allLines.Select(line =>
        {
          var split = line.Split(',');
          return new object[] { split[0], split[1] };
        });
      }
    }
  }
}
