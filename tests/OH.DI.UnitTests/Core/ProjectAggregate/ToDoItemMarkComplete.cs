using OH.DI.Core.DigitalCredentialAggregate.Events;
using Xunit;

namespace OH.DI.UnitTests.Core.DigitalCredentialAggregate;

public class ToDoItemMarkComplete
{
  [Fact]
  public void SetsIsDoneToTrue()
  {
    var item = new ToDoItemBuilder()
        .WithDefaultValues()
        .Description("")
        .Build();

    item.MarkComplete();

    Assert.True(item.IsDone);
  }

  [Fact]
  public void RaisesToDoItemCompletedEvent()
  {
    var item = new ToDoItemBuilder().Build();

    item.MarkComplete();

    Assert.Single(item.Events);
    Assert.IsType<AssuredClaimCompletedEvent>(item.Events.First());
  }
}
