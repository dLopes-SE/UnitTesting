using Xunit;

namespace XUnitTests.Tests
{
  [Collection("Customer")]
  public class CustomerDetailsTests
  {
    private readonly CustomerFixture _customerFixture;
    public CustomerDetailsTests(CustomerFixture customerFixture)
    {
      _customerFixture = customerFixture;
    }

    [Fact]
    public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
    {
      Assert.Equal("Dylan Lopes", _customerFixture.customer.GetFullName("Dylan", "Lopes"));
    }
  }
}
