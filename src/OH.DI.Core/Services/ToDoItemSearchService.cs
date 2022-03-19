using Ardalis.Result;
using OH.DI.Core.Interfaces;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.Services;

public class ToDoItemSearchService : IToDoItemSearchService
{
  private readonly IRepository<DigitalCredential> _repository;

  public ToDoItemSearchService(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  public async Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string DigitalCredentialId, string searchString)
  {
    if (string.IsNullOrEmpty(searchString))
    {
      var errors = new List<ValidationError>();
      errors.Add(new ValidationError()
      {
        Identifier = nameof(searchString),
        ErrorMessage = $"{nameof(searchString)} is required."
      });
      return Result<List<ToDoItem>>.Invalid(errors);
    }

    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (DigitalCredential == null) return Result<List<ToDoItem>>.NotFound();

    var incompleteSpec = new IncompleteItemsSearchSpec(searchString);

    try
    {
      var items = incompleteSpec.Evaluate(DigitalCredential.Items).ToList();

      return new Result<List<ToDoItem>>(items);
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<ToDoItem>>.Error(new[] { ex.Message });
    }
  }

  public async Task<Result<ToDoItem>> GetNextIncompleteItemAsync(string DigitalCredentialId)
  {
    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);
    if (DigitalCredential == null)
    {
      return Result<ToDoItem>.NotFound();
    }

    var incompleteSpec = new IncompleteItemsSpec();

    var items = incompleteSpec.Evaluate(DigitalCredential.Items).ToList();

    if (!items.Any())
    {
      return Result<ToDoItem>.NotFound();
    }

    return new Result<ToDoItem>(items.First());
  }
}
