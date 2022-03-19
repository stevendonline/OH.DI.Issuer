using Ardalis.Result;
using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(string DigitalCredentialId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string DigitalCredentialId, string searchString);
}
