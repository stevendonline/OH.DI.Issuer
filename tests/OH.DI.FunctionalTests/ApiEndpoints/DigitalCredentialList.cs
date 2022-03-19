using Ardalis.HttpClientTestExtensions;
using OH.DI.Web;
using OH.DI.Web.Endpoints.DigitalCredentialEndpoints;
using Xunit;

namespace OH.DI.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class DigitalCredentialList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public DigitalCredentialList(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneDigitalCredential()
  {
    var result = await _client.GetAndDeserialize<DigitalCredentialListResponse>("/DigitalCredentials");

    Assert.Single(result.DigitalCredentials);
    Assert.Contains(result.DigitalCredentials, i => i.Name == SeedData.TestDigitalCredential1.Name);
  }
}
