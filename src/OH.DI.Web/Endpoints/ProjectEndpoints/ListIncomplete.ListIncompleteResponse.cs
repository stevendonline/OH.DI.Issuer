namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class ListIncompleteResponse
{
  public ListIncompleteResponse(string projectId, List<ToDoItemRecord> incompleteItems)
  {
    ProjectId = projectId;
    IncompleteItems = incompleteItems;
  }
  public string ProjectId { get; set; }
  public List<ToDoItemRecord> IncompleteItems { get; set; }
}
