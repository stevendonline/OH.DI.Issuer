using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using OH.DI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace OH.DI.Web.Controllers;

[Route("[controller]")]
public class DigitalCredentialController : Controller
{
  private readonly IRepository<DigitalCredential> _DigitalCredentialRepository;

  public DigitalCredentialController(IRepository<DigitalCredential> DigitalCredentialRepository)
  {
    _DigitalCredentialRepository = DigitalCredentialRepository;
  }

  // GET DigitalCredential/{DigitalCredentialId?}
  [HttpGet("{DigitalCredentialId}")]
  public async Task<IActionResult> Index(string DigitalCredentialId = "1")
  {
    var spec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _DigitalCredentialRepository.GetBySpecAsync(spec);
    if (DigitalCredential == null)
    {
      return NotFound();
    }

    var dto = new DigitalCredentialViewModel
    {
      Id = DigitalCredential.Id,
      Name = DigitalCredential.Name,
      Items = DigitalCredential.Items
                    .Select(item => AssuredClaimViewModel.FromToDoItem(item))
                    .ToList()
    };
    return View(dto);
  }
}
