using Ardalis.Specification;

namespace OH.DI.Core.DigitalCredentialAggregate.Specifications;

public class ToDoItemsByIdSpec : Specification<ToDoItem>
{
  public ToDoItemsByIdSpec(string id)
  {
    Query.Where(item => item.DigitalCredentialId == id);
  }
}
