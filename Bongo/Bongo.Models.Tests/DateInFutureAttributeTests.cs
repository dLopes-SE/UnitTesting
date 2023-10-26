using Bongo.Models.ModelValidations;

namespace Bongo.Models.Tests
{
  [Trait("Category", "DateInFutureAttributeTests")]
  public class DateInFutureAttributeTests
  {
    [Theory]
    [InlineData(100)]
    [InlineData(200)]
    public void DateValidator_InputExpectedDate_DateValidity(int addSeconds)
    {
      Assert.True(new DateInFutureAttribute(() => DateTime.Now).IsValid(DateTime.Now.AddSeconds(addSeconds)));
    }

    [Fact]
    public void DateInFutureAttribute_VerifyErrorMessage()
    {
      Assert.Equal("Date must be in the future", new DateInFutureAttribute(() => DateTime.Now).ErrorMessage);
    }
  }
}