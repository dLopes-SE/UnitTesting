namespace TDD.Tests
{
  public class DefaultPasswordValidatorTest
  {
    [Fact]
    public void Validate_GivenLongerThan8Chars_ReturnsTrue()
    {
      var testTarget = new DefaultPasswordValidator();
      var password = "123456789";

      Assert.True(testTarget.Validate(password));
    }

    [Fact]
    public void Validate_GivenShorterThan15Chars_ReturnsTrue()
    {
      var testTarget = new DefaultPasswordValidator();
      var password = "123456789";

      Assert.True(testTarget.Validate(password));
    }

  }
}