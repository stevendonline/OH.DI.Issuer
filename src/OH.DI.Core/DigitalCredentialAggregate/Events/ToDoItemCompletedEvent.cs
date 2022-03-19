using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel;

namespace OH.DI.Core.DigitalCredentialAggregate.Events;

public class ToDoItemCompletedEvent : BaseDomainEvent
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
