using Ardalis.GuardClauses;
using OH.DI.Core.ProjectAggregate.Events;
using OH.DI.SharedKernel;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.ProjectAggregate;

public class DigitalCredential : BaseEntity, IAggregateRoot
{
  public string UserId { get; private set; }
  public string Name { get; private set; }

  private List<ToDoItem> _items = new List<ToDoItem>();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public DigitalCredentialStatus Status => _items.All(i => i.IsDone) ? DigitalCredentialStatus.Complete : DigitalCredentialStatus.InProgress;

  public DigitalCredential(string userId, string name)
  {
    UserId = userId;
    Id = Guid.NewGuid().ToString();
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public DigitalCredential(string userId, string id, string name)
  {
    UserId = userId;
    Id = id;
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewAttributeAddedEvent(this, newItem);
    Events.Add(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
