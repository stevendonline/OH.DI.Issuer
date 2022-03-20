using Ardalis.Specification;

namespace OH.DI.Core.DigitalCredentialAggregate.Specifications;

public class IncompleteClaimsSpec : Specification<AssuredClaim>
{
  public IncompleteClaimsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
