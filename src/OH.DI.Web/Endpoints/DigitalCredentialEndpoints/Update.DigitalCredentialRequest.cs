using System.ComponentModel.DataAnnotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class UpdateDigitalCredentialRequest
{
  public const string Route = "/DigitalCredentials";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
