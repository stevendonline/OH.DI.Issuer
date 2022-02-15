using System.Linq;
using System.Threading.Tasks;
using OH.DI.Core.ProjectAggregate;
using OH.DI.Core.ProjectAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using OH.DI.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OH.DI.Web.Pages.ToDoRazorPage;

public class IndexModel : PageModel
{
  private readonly IRepository<Project> _repository;

  [BindProperty(SupportsGet = true)]
  public string ProjectId { get; set; }
  public string Message { get; set; } = "";

  public ProjectDTO? Project { get; set; }

  public IndexModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
    var project = await _repository.GetBySpecAsync(projectSpec);

    if (project == null)
    {
      Message = "No project found.";
      return;
    }

    Project = new ProjectDTO
    (
        id: project.Id,
        name: project.Name,
        items: project.Items
        .Select(item => ToDoItemDTO.FromToDoItem(item))
        .ToList()
    );
  }
}
