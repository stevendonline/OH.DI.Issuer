using Ardalis.Result;
using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Core.Interfaces;

public interface IAssuredClaimSearchService
{
  Task<Result<AssuredClaim>> GetNextIncompleteItemAsync(string DigitalCredentialId);
  Task<Result<List<AssuredClaim>>> GetAllIncompleteItemsAsync(string DigitalCredentialId, string searchString);
}
