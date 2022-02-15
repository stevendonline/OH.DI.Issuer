
namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class GetProjectByIdRequest
{
  public const string Route = "/Projects/{ProjectId}";
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId}", projectId.ToString());

  public string ProjectId { get; set; }
}
