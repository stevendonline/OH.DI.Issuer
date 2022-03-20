using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using Xunit;

namespace OH.DI.UnitTests.Core.Specifications;

public class IncompleteItemsSpecificationConstructor
{
  [Fact]
  public void FilterCollectionToOnlyReturnItemsWithIsDoneFalse()
  {
    var item1 = new AssuredClaim();
    var item2 = new AssuredClaim();
    var item3 = new AssuredClaim();
    item3.MarkComplete();

    var items = new List<AssuredClaim>() { item1, item2, item3 };

    var spec = new IncompleteClaimsSpec();

    var filteredList = spec.Evaluate(items);

    Assert.Contains(item1, filteredList);
    Assert.Contains(item2, filteredList);
    Assert.DoesNotContain(item3, filteredList);
  }
}
