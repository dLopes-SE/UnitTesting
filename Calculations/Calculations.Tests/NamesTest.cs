using Xunit;

namespace Calculations.Tests
{
  public class NamesTest
  {
    [Fact]
    public void MakeFullNameTest()
    {
      var names = new Names();
      // There are some optional arguments to ignore some situations (in this case, we're using ignoreCase)
      Assert.Equal("Dylan Lopes", names.MakeFullName("dylan", "Lopes"), ignoreCase: true);
    }

    [Fact]
    public void MakeName_ContainsTest()
    {
      var names = new Names();
      Assert.Contains("Dylan", names.MakeFullName("dylan", "Lopes"), StringComparison.InvariantCultureIgnoreCase);
    }

    [Fact]
    public void MakeName_StartsWithTest()
    {
      var names = new Names();
      Assert.StartsWith("Dylan", names.MakeFullName("dylan", "Lopes"), StringComparison.InvariantCultureIgnoreCase);
    }

    [Fact]
    public void MakeName_RegexText()
    {
      var names = new Names();
      Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", names.MakeFullName("Dylan", "Lopes"));
    }
  }
}
