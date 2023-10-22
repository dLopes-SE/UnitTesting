using Xunit;
using Xunit.Abstractions;

namespace XUnitTests.Tests
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
    private readonly ITestOutputHelper _outputHelper;

    public CalculationTests(CalculatorFixture calculatorFixture, ITestOutputHelper testOutputHelper)
    {
      _calculatorFixture = calculatorFixture;
      _outputHelper = testOutputHelper;
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotIncludeZero()
    {
      _outputHelper.WriteLine("FiboDoesNotIncludeZero");
      var calc = _calculatorFixture.Calc;
      Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotInclude13()
    {
      _outputHelper.WriteLine("FiboDoesNotInclude13");
      var calc = _calculatorFixture.Calc;
      Assert.Contains(13, calc.FiboNumbers);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void FiboDoesNotInclude4()
    {
      _outputHelper.WriteLine("FiboDoesNotInclude13");
      var calc = _calculatorFixture.Calc;
      Assert.DoesNotContain(14, calc.FiboNumbers);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void CheckCollection()
    {
      _outputHelper.WriteLine("CheckCollection. Test Starting at {0}", DateTime.Now);
      var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };

      _outputHelper.WriteLine("Creating an instance of Fibo Class (Calculations)");
      var calc = _calculatorFixture.Calc;

      _outputHelper.WriteLine("Asserting...");
      Assert.Equal(expectedCollection, calc.FiboNumbers);

      _outputHelper.WriteLine("End");
    }
  }
}
