
using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class GetDigtialCredentialByIdResponse
{
  public GetDigtialCredentialByIdResponse(string id, string name, List<AssuredClaim> items)
  {
    Id = id;
    Name = name;
    AssuredClaims = items;
  }

  public string Id { get; set; }
  public string Name { get; set; }
  //public List<AssuredClaimRecord> Items { get; set; } = new();
  public List<AssuredClaim> AssuredClaims { get; set; }
}
