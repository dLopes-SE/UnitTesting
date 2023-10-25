namespace SproutMethod.Tests
{
  public class LegacyClassTest
  {
    [Fact]
    public void GetValidItems_GivenTwoDictionaries_ReturnCommonItems()
    {
      var legacyClass = new LegacyClass();

      var dict1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 } };
      var dict2 = new Dictionary<int, int>() { { 7, 0 }, { 8, 0 }, { 9, 0 }, { 1, 800 } };
      var expectedResult = new Dictionary<int, int>() { { 2, 0 }, { 3, 0 } };
      Assert.Equal(expectedResult, legacyClass.GetValidItems(dict1, dict2));
    }
  }
}