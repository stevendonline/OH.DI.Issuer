using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.UnitTests;

// Learn more about test builders:
// https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
public class ToDoItemBuilder
{
  private AssuredClaim _todo = new AssuredClaim();

  public ToDoItemBuilder Id(string id)
  {
    _todo.Id = id;
    return this;
  }

  public ToDoItemBuilder Title(string title)
  {
    _todo.Name = title;
    return this;
  }

  public ToDoItemBuilder Description(string description)
  {
    _todo.Description = description;
    return this;
  }

  public ToDoItemBuilder WithDefaultValues()
  {
    _todo = new AssuredClaim() { Id = 1.ToString(), Name = "Test Item", Description = "Test Description" };

    return this;
  }

  public AssuredClaim Build() => _todo;
}
