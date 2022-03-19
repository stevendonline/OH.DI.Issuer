namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class CreateDigitalCredentialResponse
{
  public CreateDigitalCredentialResponse(string id, string name)
  {
    Id = id;
    Name = name;
  }
  public string Id { get; set; }
  public string Name { get; set; }
}
