using Xunit;

namespace XUnitTests.Tests
{
  // This class is needed so that XUnit knows the common class CustomerFixture around
  // all other classes
  [CollectionDefinition("Customer")]
  public class CustomerFixtureCollection : ICollectionFixture<CustomerFixture>
  {

  }
}
