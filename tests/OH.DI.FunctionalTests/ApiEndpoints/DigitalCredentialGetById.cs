using Ardalis.HttpClientTestExtensions;
using OH.DI.Web;
using OH.DI.Web.Endpoints.DigitalCredentialEndpoints;
using Xunit;

namespace OH.DI.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class DigitalCredentialGetById : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public DigitalCredentialGetById(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedDigitalCredentialGivenId1()
  {
    var result = await _client.GetAndDeserialize<GetDigtialCredentialByIdResponse>(GetDigitalCredentialByIdRequest.BuildRoute(1));

    Assert.Equal(1.ToString(), result.Id);
    Assert.Equal(SeedData.TestDigitalCredential1.Name, result.Name);
    //Assert.Equal(3, result.Items.Count);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetDigitalCredentialByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFound(route);
  }
}
