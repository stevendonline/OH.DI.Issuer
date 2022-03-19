namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class ListIncompleteResponse
{
  public ListIncompleteResponse(string digitalCredentialId, List<ToDoItemRecord> incompleteItems)
  {
    DigitalCredentialId = digitalCredentialId;
    IncompleteItems = incompleteItems;
  }
  public string DigitalCredentialId { get; set; }
  public List<ToDoItemRecord> IncompleteItems { get; set; }
}
