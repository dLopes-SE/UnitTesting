using Xunit;

namespace XUnitTests
{
  // Important! Make sure that the test target (object) is thread safe!
  public class CalculatorFixture : IDisposable
  {
    public Calculations Calc => new();

    public void Dispose()
    {
      // Clean here what's needed
    }
  }

  public class CalculationTests : IClassFixture<CalculatorFixture>
  {
    private readonly CalculatorFixture _calculatorFixture;

    public CalculationTests(CalculatorFixture calculatorFixture)
    {
      _calculatorFixture = calculatorFixture;
    }
    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotIncludeZero()
    {
      var calc = _calculatorFixture.Calc;
      Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotInclude13()
    {
      var calc = _calculatorFixture.Calc;
      Assert.Contains(13, calc.FiboNumbers);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotInclude4()
    {
      var calc = _calculatorFixture.Calc;
      Assert.DoesNotContain(14, calc.FiboNumbers);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void CheckCollection()
    {
      var calc = _calculatorFixture.Calc;
      var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
      Assert.Equal(expectedCollection, calc.FiboNumbers);
    }
  }
}
