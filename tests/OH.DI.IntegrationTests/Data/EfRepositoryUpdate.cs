using OH.DI.Core.DigitalCredentialAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace OH.DI.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  //[Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a DigitalCredential
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var DigitalCredential = new DigitalCredential("1", initialName);

    await repository.AddAsync(DigitalCredential);

    // detach the item so we get a different instance
    _dbContext.Entry(DigitalCredential).State = EntityState.Detached;

    // fetch the item and update its title
    var newDigitalCredential = (await repository.ListAsync())
        .FirstOrDefault(DigitalCredential => DigitalCredential.Name == initialName);
    if (newDigitalCredential == null)
    {
      Assert.NotNull(newDigitalCredential);
      return;
    }
    Assert.NotSame(DigitalCredential, newDigitalCredential);
    var newName = Guid.NewGuid().ToString();
    newDigitalCredential.UpdateName(newName);

    // Update the item
    await repository.UpdateAsync(newDigitalCredential);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(DigitalCredential => DigitalCredential.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(DigitalCredential.Name, updatedItem?.Name);
    Assert.Equal(newDigitalCredential.Id, updatedItem?.Id);
  }
}
