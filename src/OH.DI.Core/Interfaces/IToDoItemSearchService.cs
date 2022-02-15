using Ardalis.Result;
using OH.DI.Core.ProjectAggregate;

namespace OH.DI.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(string projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string projectId, string searchString);
}
