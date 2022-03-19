
namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class GetDigtialCredentialByIdResponse
{
  public GetDigtialCredentialByIdResponse(string id, string name, List<ToDoItemRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  public string Id { get; set; }
  public string Name { get; set; }
  public List<ToDoItemRecord> Items { get; set; } = new();
}
