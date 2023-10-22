using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xunit;

namespace XUnitTests
{
  public class CalculationTests
  {
    [Fact]
    public void FiboDoesNotIncludeZero()
    {
      var calc = new Calculations();
      Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
    }

    [Fact]
    public void FiboDoesNotInclude13()
    {
      var calc = new Calculations();
      Assert.Contains(13, calc.FiboNumbers);
    }

    [Fact]
    public void FiboDoesNotInclude4()
    {
      var calc = new Calculations();
      Assert.DoesNotContain(14, calc.FiboNumbers);
    }

    [Fact]
    public void CheckCollection()
    {
      var calc = new Calculations();
      var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
      Assert.Equal(expectedCollection, calc.FiboNumbers);
    }
  }
}
