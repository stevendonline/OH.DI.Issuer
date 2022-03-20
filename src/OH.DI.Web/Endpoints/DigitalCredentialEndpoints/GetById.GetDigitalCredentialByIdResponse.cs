
namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class GetDigtialCredentialByIdResponse
{
  public GetDigtialCredentialByIdResponse(string id, string name, List<AssuredClaimRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  public string Id { get; set; }
  public string Name { get; set; }
  public List<AssuredClaimRecord> Items { get; set; } = new();
}
