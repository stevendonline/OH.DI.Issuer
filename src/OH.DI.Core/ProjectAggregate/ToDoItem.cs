using OH.DI.Core.ProjectAggregate.Events;
using OH.DI.SharedKernel;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.ProjectAggregate;

public class ToDoItem : BaseEntity, IAggregateRoot
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public bool IsDone { get; private set; }

  public string ProjectId { get; set; }

  public void MarkComplete()
  {
    if (!IsDone)
    {
      IsDone = true;

      Events.Add(new ToDoItemCompletedEvent(this));
    }
  }

  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}
