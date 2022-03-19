
namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class GetProjectByIdRequest
{
  public const string Route = "/DigitalCredentials/{DigitalCredentialId}";
  public static string BuildRoute(int projectId) => Route.Replace("{DigitalCredentialId}", projectId.ToString());

  public string ProjectId { get; set; }
}
