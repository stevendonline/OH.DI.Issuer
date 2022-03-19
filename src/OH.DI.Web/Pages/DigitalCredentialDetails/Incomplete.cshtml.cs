using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
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
    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec("1"); // TODO: get from route
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);
    if (DigitalCredential == null)
    {
      return;
    }
    var spec = new IncompleteItemsSpec();

    ToDoItems = spec.Evaluate(DigitalCredential.Items).ToList();
  }
}
