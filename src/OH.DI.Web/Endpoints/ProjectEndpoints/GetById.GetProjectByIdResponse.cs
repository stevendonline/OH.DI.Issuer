
namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class GetProjectByIdResponse
{
  public GetProjectByIdResponse(string id, string name, List<ToDoItemRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  public string Id { get; set; }
  public string Name { get; set; }
  public List<ToDoItemRecord> Items { get; set; } = new();
}
