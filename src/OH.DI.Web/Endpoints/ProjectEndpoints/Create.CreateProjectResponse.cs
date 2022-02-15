namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class CreateProjectResponse
{
  public CreateProjectResponse(string id, string name)
  {
    Id = id;
    Name = name;
  }
  public string Id { get; set; }
  public string Name { get; set; }
}
