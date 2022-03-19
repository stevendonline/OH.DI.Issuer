using OH.DI.SharedKernel;

namespace OH.DI.Core.ProjectAggregate.Events;

public class NewAttributeAddedEvent : BaseDomainEvent
{
  public ToDoItem NewItem { get; set; }
  public DigitalCredential DigtialCred { get; set; }

  public NewAttributeAddedEvent(DigitalCredential cred,
      ToDoItem newItem)
  {
    DigtialCred = cred;
    NewItem = newItem;
  }
}
