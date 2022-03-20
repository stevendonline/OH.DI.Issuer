using OH.DI.Core.DigitalCredentialAggregate;
using Xunit;

namespace OH.DI.UnitTests.Core.DigitalCredentialAggregate;

public class DigitalCredential_AddItem
{
  private DigitalCredential _testDigitalCredential = new DigitalCredential("1", "some name");

  [Fact]
  public void AddsItemToItems()
  {
    var _testItem = new AssuredClaim
    {
      Name = "title",
      Description = "description"
    };

    _testDigitalCredential.AddItem(_testItem);

    Assert.Contains(_testItem, _testDigitalCredential.Items);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => _testDigitalCredential.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}
