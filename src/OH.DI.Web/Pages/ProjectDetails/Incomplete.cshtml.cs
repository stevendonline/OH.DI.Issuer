using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OH.DI.Core.ProjectAggregate;
using OH.DI.Core.ProjectAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OH.DI.Web.Pages.ToDoRazorPage;

public class IncompleteModel : PageModel
{
  private readonly IRepository<DigitalCredential> _repository;

  public List<ToDoItem>? ToDoItems { get; set; }

  public IncompleteModel(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec("1"); // TODO: get from route
    var project = await _repository.GetBySpecAsync(projectSpec);
    if (project == null)
    {
      return;
    }
    var spec = new IncompleteItemsSpec();

    ToDoItems = spec.Evaluate(project.Items).ToList();
  }
}
