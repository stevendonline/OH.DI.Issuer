namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class DeleteDigitalCredentialRequest
{
  public const string Route = "/DigitalCredentials/{DigitalCredentialId:int}";
  public static string BuildRoute(int digitalCredentialId) => Route.Replace("{DigitalCredentialId:int}", digitalCredentialId.ToString());

  public int DigitalCredentialId { get; set; }
}
