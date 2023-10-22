using Xunit;
using Xunit.Abstractions;

namespace XUnitTests.Tests
{
  public class TestCollectionOrderer : ITestCollectionOrderer
  {
    public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
    {
      return testCollections.OrderBy(t => t.DisplayName);
    }
  }
}
