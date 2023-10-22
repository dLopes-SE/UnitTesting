using System.Runtime.CompilerServices;
using Xunit;

namespace XUnitTests.Tests
{
  public class CostumerTests
  {
    [Fact]
    [Trait("Category", "Costumer")]
    public void CheckNameNotEmpty()
    {
      var costumer = new Costumer();
      Assert.NotNull(costumer.Name);
      Assert.False(string.IsNullOrEmpty(costumer.Name));
    }

    [Fact]
    [Trait("Category", "Costumer")]
    public void CheckAgeBetween25and40()
    {
      var costumer = new Costumer();
      Assert.InRange<int>(costumer.Age, 25, 40);
    }

    [Fact]
    [Trait("Category", "Costumer")]
    public void GetAnExceptionTest()
    {
      var costumer = new Costumer();
      Assert.Throws<ArgumentException>(() => costumer.GetAnException());
    }

    [Fact]
    [Trait("Category", "Costumer")]
    public void GetAnExceptionMessageText()
    {
      var costumer = new Costumer();
      var exceptionDetais = Assert.Throws<ArgumentException>(() => costumer.GetAnException());
      Assert.Equal("Hello", exceptionDetais.Message);
    }

    [Fact]
    [Trait("Category", "LoyalCostumer")]
    public void LoyalCostumerForOrdersG100Test()
    {
      var costumer = CostumerFactory.CreaterCostumerInstance(101);
      Assert.IsType<LoyalCostumer>(costumer);
    }

    [Fact]
    [Trait("Category", "LoyalCostumer")]
    public void LoyalCostumerCheckDiscountTest()
    {
      var costumer = CostumerFactory.CreaterCostumerInstance(102);
      var loyalCostumer = Assert.IsType<LoyalCostumer>(costumer);
      Assert.Equal(10, loyalCostumer.Discount);
    }
  }
}
