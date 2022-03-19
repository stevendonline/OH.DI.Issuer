using Microsoft.AspNetCore.Mvc;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class ListIncompleteRequest
{
  [FromRoute]
  public string DigitalCredentialId { get; set; }
  [FromQuery]
  public string? SearchString { get; set; }
}
