using System.Collections.Generic;

namespace OH.DI.Web.ViewModels;

public class DigitalCredentialViewModel
{
  public string Id { get; set; }
  public string? Name { get; set; }
  public List<ToDoItemViewModel> Items = new();
}
