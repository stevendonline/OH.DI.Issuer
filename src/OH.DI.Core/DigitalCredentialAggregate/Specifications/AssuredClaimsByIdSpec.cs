using Ardalis.Specification;

namespace OH.DI.Core.DigitalCredentialAggregate.Specifications;

public class AssuredClaimsByIdSpec : Specification<AssuredClaim>
{
  public AssuredClaimsByIdSpec(string id)
  {
    Query.Where(item => item.DigitalCredentialId == id);
  }
}
