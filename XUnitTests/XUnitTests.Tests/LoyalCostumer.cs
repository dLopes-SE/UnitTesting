using System.ComponentModel.Design;

namespace XUnitTests.Tests
{
  public class LoyalCostumer : Costumer
  {
    public int Discount { get; set; }
    public LoyalCostumer()
    {
      Discount = 10;
    }
  }

  public static class CostumerFactory
  {
    public static Costumer CreaterCostumerInstance(int orderCount)
    {
      if (orderCount <= 100)
        return new Costumer();

      return new LoyalCostumer();
    }
  }
}
