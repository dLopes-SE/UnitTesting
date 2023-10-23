using System.Data.Common;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTests.Tests
{
  public class IsOddOrEvenDataAtrribute : DataAttribute
  {
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
      return TestDataShare.IsOddOrEvenExternalData;
    }

  }
}
