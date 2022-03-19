using OH.DI.Core.DigitalCredentialAggregate;
using Xunit;

namespace OH.DI.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  //[Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a DigitalCredential
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var DigitalCredential = new DigitalCredential("1", initialName);
    await repository.AddAsync(DigitalCredential);

    // delete the item
    await repository.DeleteAsync(DigitalCredential);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        DigitalCredential => DigitalCredential.Name == initialName);
  }
}
