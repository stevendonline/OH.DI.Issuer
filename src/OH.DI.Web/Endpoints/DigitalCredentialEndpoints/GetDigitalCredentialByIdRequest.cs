
namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class GetDigitalCredentialByIdRequest
{
  public const string Route = "/DigitalCredentials/{DigitalCredentialId}";
  public static string BuildRoute(int digitalCredentialId) => Route.Replace("{DigitalCredentialId}", digitalCredentialId.ToString());

  public string? DigitalCredentialId { get; set; }
}
