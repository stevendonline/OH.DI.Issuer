using Ardalis.Specification;
using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Core.DigitalCredentialAggregate.Specifications;

public class DigitalCredentialByIdWithItemsSpec : Specification<DigitalCredential>, ISingleResultSpecification
{
  public DigitalCredentialByIdWithItemsSpec(string DigitalCredentialId)
  {
    Query
        .Where(DigitalCredential => DigitalCredential.Id == DigitalCredentialId);
        //.Include(DigitalCredential => DigitalCredential.Items);
  }
}
