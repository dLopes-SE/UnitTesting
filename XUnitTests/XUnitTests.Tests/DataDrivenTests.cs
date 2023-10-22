using Xunit;

namespace XUnitTests.Tests
{
  public class DataDrivenTests
  {
    [Theory]
    [Trait("Category", "DataDriven")]
    [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
    public void IsOdd_TestOddAndEven(int value, bool expected)
    {
      var obj = new DataDriven();
      Assert.Equal(expected, obj.IsOdd(value));
    }

    [Theory]
    [Trait("Category", "DataDriven")]
    [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
    public void IsOdd_TestOddAndEven_ExternalData(int value, bool expected)
    {
      var obj = new DataDriven();
      Assert.Equal(expected, obj.IsOdd(value));
    }
  }
}