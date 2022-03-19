﻿using Ardalis.Result;
using OH.DI.Core.Interfaces;
using OH.DI.Core.ProjectAggregate;
using OH.DI.Core.ProjectAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.Services;

public class ToDoItemSearchService : IToDoItemSearchService
{
  private readonly IRepository<DigitalCredential> _repository;

  public ToDoItemSearchService(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  public async Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string projectId, string searchString)
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

    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.GetBySpecAsync(projectSpec);

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (project == null) return Result<List<ToDoItem>>.NotFound();

    var incompleteSpec = new IncompleteItemsSearchSpec(searchString);

    try
    {
      var items = incompleteSpec.Evaluate(project.Items).ToList();

      return new Result<List<ToDoItem>>(items);
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<ToDoItem>>.Error(new[] { ex.Message });
    }
  }

  public async Task<Result<ToDoItem>> GetNextIncompleteItemAsync(string projectId)
  {
    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.GetBySpecAsync(projectSpec);
    if (project == null)
    {
      return Result<ToDoItem>.NotFound();
    }

    var incompleteSpec = new IncompleteItemsSpec();

    var items = incompleteSpec.Evaluate(project.Items).ToList();

    if (!items.Any())
    {
      return Result<ToDoItem>.NotFound();
    }

    return new Result<ToDoItem>(items.First());
  }
}
