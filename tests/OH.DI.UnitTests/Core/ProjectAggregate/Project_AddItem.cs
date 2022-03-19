using OH.DI.Core.ProjectAggregate;
using Xunit;

namespace OH.DI.UnitTests.Core.ProjectAggregate;

public class Project_AddItem
{
  private DigitalCredential _testProject = new DigitalCredential("1", "some name");

  [Fact]
  public void AddsItemToItems()
  {
    var _testItem = new ToDoItem
    {
      Title = "title",
      Description = "description"
    };

    _testProject.AddItem(_testItem);

    Assert.Contains(_testItem, _testProject.Items);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => _testProject.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}
