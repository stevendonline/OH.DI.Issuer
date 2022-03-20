using Ardalis.Specification;

namespace OH.DI.Core.DigitalCredentialAggregate.Specifications;

public class IncompleteClaimsSearchSpec : Specification<AssuredClaim>
{
  public IncompleteClaimsSearchSpec(string searchString)
  {
    Query
        .Where(item => !item.IsDone &&
        (item.Name.Contains(searchString) ||
        item.Description.Contains(searchString)));
  }
}
