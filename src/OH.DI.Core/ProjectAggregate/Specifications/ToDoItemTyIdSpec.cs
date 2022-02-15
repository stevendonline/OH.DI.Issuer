using Ardalis.Specification;

namespace OH.DI.Core.ProjectAggregate.Specifications;

public class ToDoItemsByIdSpec : Specification<ToDoItem>
{
  public ToDoItemsByIdSpec(string id)
  {
    Query.Where(item => item.ProjectId == id);
  }
}
