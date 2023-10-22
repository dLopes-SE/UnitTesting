using System.ComponentModel.Design;

namespace XUnitTests.Tests
{
  public class LoyalCustomer : Customer
  {
    public int Discount { get; set; }
    public LoyalCustomer()
    {
      Discount = 10;
    }
  }

  public static class CustomerFactory
  {
    public static Customer CreaterCustomerInstance(int orderCount)
    {
      if (orderCount <= 100)
        return new Customer();

      return new LoyalCustomer();
    }
  }
}
