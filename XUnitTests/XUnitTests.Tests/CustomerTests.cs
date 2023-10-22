using Xunit;

namespace XUnitTests.Tests
{
  [Collection("Customer")]
  public class CustomerTests
  {
    private readonly CustomerFixture _customerFixture;

    public CustomerTests(CustomerFixture customerFixture)
    {
      _customerFixture = customerFixture;
    }

    [Fact]
    [Trait("Category", "Customer")]
    public void CheckNameNotEmpty()
    {
      var customer = _customerFixture.customer;
      Assert.NotNull(customer.Name);
      Assert.False(string.IsNullOrEmpty(customer.Name));
    }

    [Fact]
    [Trait("Category", "Customer")]
    public void CheckAgeBetween25and40()
    {
      var customer = _customerFixture.customer;
      Assert.InRange<int>(customer.Age, 25, 40);
    }

    [Fact]
    [Trait("Category", "Customer")]
    public void GetAnExceptionTest()
    {
      var customer = _customerFixture.customer;
      Assert.Throws<ArgumentException>(() => customer.GetAnException());
    }

    [Fact]
    [Trait("Category", "Customer")]
    public void GetAnExceptionMessageText()
    {
      var customer = _customerFixture.customer;
      var exceptionDetais = Assert.Throws<ArgumentException>(() => customer.GetAnException());
      Assert.Equal("Hello", exceptionDetais.Message);
    }

    [Fact]
    [Trait("Category", "LoyalCustomer")]
    public void LoyalCustomerForOrdersG100Test()
    {
      var customer = CustomerFactory.CreaterCustomerInstance(101);
      Assert.IsType<LoyalCustomer>(customer);
    }

    [Fact]
    [Trait("Category", "LoyalCustomer")]
    public void LoyalCustomerCheckDiscountTest()
    {
      var customer = CustomerFactory.CreaterCustomerInstance(102);
      var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
      Assert.Equal(10, loyalCustomer.Discount);
    }
  }
}
