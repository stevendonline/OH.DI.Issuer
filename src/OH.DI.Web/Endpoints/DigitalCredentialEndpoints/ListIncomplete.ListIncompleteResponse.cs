namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class ListIncompleteResponse
{
  public ListIncompleteResponse(string digitalCredentialId, List<AssuredClaimRecord> incompleteItems)
  {
    DigitalCredentialId = digitalCredentialId;
    IncompleteItems = incompleteItems;
  }
  public string DigitalCredentialId { get; set; }
  public List<AssuredClaimRecord> IncompleteItems { get; set; }
}
