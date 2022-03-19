using OH.DI.Core.ProjectAggregate;
using Xunit;

namespace OH.DI.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  //[Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new DigitalCredential("1", initialName);
    await repository.AddAsync(project);

    // delete the item
    await repository.DeleteAsync(project);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        project => project.Name == initialName);
  }
}
