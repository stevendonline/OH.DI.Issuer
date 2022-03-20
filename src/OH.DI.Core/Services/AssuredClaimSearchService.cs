using Ardalis.Result;
using OH.DI.Core.Interfaces;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.Services;

public class AssuredClaimSearchService : IAssuredClaimSearchService
{
  private readonly IRepository<DigitalCredential> _repository;

  public AssuredClaimSearchService(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  public async Task<Result<List<AssuredClaim>>> GetAllIncompleteItemsAsync(string DigitalCredentialId, string searchString)
  {
    if (string.IsNullOrEmpty(searchString))
    {
      var errors = new List<ValidationError>();
      errors.Add(new ValidationError()
      {
        Identifier = nameof(searchString),
        ErrorMessage = $"{nameof(searchString)} is required."
      });
      return Result<List<AssuredClaim>>.Invalid(errors);
    }

    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (DigitalCredential == null) return Result<List<AssuredClaim>>.NotFound();

    var incompleteSpec = new IncompleteClaimsSearchSpec(searchString);

    try
    {
      var items = incompleteSpec.Evaluate(DigitalCredential.Items).ToList();

      return new Result<List<AssuredClaim>>(items);
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<AssuredClaim>>.Error(new[] { ex.Message });
    }
  }

  public async Task<Result<AssuredClaim>> GetNextIncompleteItemAsync(string DigitalCredentialId)
  {
    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);
    if (DigitalCredential == null)
    {
      return Result<AssuredClaim>.NotFound();
    }

    var incompleteSpec = new IncompleteClaimsSpec();

    var items = incompleteSpec.Evaluate(DigitalCredential.Items).ToList();

    if (!items.Any())
    {
      return Result<AssuredClaim>.NotFound();
    }

    return new Result<AssuredClaim>(items.First());
  }
}
