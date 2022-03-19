using OH.DI.Core.DigitalCredentialAggregate;
using Xunit;

namespace OH.DI.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  //[Fact]
  public async Task AddsDigitalCredentialAndSetsId()
  {
    var testDigitalCredentialName = "testDigitalCredential";
    var repository = GetRepository();
    var DigitalCredential = new DigitalCredential("1", testDigitalCredentialName);

    await repository.AddAsync(DigitalCredential);

    var newDigitalCredential = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testDigitalCredentialName, newDigitalCredential?.Name);
    //Assert.True(newDigitalCredential?.Id > 0);
  }
}
