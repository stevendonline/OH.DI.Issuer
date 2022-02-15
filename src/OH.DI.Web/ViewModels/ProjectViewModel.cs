using System.Collections.Generic;

namespace OH.DI.Web.ViewModels;

public class ProjectViewModel
{
  public string Id { get; set; }
  public string? Name { get; set; }
  public List<ToDoItemViewModel> Items = new();
}
