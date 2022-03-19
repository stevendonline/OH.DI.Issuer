using System.ComponentModel.DataAnnotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class CreateDigitalCredentialRequest
{
  public const string Route = "/DigitalCredentials";

  [Required]
  public string? Name { get; set; }
}
