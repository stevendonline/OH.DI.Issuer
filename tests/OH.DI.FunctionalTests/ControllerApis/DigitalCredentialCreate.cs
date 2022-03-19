using Ardalis.HttpClientTestExtensions;
using OH.DI.Web;
using OH.DI.Web.ApiModels;
using Xunit;

namespace OH.DI.FunctionalTests.ControllerApis;

[Collection("Sequential")]
public class DigitalCredentialCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public DigitalCredentialCreate(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneDigitalCredential()
  {
    var result = await _client.GetAndDeserialize<IEnumerable<DigitalCredentialDTO>>("/api/digitalcredentials");

    Assert.Single(result);
    Assert.Contains(result, i => i.Name == SeedData.TestDigitalCredential1.Name);
  }
}
