using Xunit;
using Calculations;

namespace Calculations.Tests
{
  public class CalculatorTest
  {
    [Fact]
    public void Add_GivenTwoIntValues_ReturnsInt()
    {
      var calc = new Calculator();
      Assert.Equal(3, calc.Add(1, 2));
    }

    [Fact]
    public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
    {
      var calc = new Calculator();
      // The 3rd argument is about decimal tolerance. In this case 
      // we got '1', which leads to a round up value -> which is correct, so the test passes
      Assert.Equal(3.6, calc.AddDouble(1.23, 2.34), 1);
    }
  }
}
