using OH.DI.Core.ProjectAggregate;
using OH.DI.Core.ProjectAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using OH.DI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OH.DI.Web.Controllers;

[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<DigitalCredential> _projectRepository;

  public ProjectController(IRepository<DigitalCredential> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  // GET project/{projectId?}
  [HttpGet("{projectId}")]
  public async Task<IActionResult> Index(string projectId = "1")
  {
    var spec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _projectRepository.GetBySpecAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProjectViewModel
    {
      Id = project.Id,
      Name = project.Name,
      Items = project.Items
                    .Select(item => ToDoItemViewModel.FromToDoItem(item))
                    .ToList()
    };
    return View(dto);
  }
}
