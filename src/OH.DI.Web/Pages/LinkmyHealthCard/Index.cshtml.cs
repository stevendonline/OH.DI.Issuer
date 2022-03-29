using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using OH.DI.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace OH.DI.Issuer.Web.Pages.LinkmyHealthCard
{
    public class IndexModel : PageModel
    {
    private readonly IRepository<DigitalCredential> _repository;

    [BindProperty(SupportsGet = true)]
    public string DigitalCredentialId { get; set; }
    public string Message { get; set; } = "";

    public DigitalCredentialDTO? DigitalCredential { get; set; }

    public IndexModel(IRepository<DigitalCredential> repository)
    {
      _repository = repository;
    }

    public async Task OnGetAsync()
    {
      var digitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
      var digitalCredential = await _repository.GetBySpecAsync(digitalCredentialSpec);

      if (digitalCredential == null)
      {
        Message = "No DigitalCredential found.";
        return;
      }

      DigitalCredential = new DigitalCredentialDTO
      (
          id: digitalCredential.Id,
          name: digitalCredential.Name,
          items: digitalCredential.AssuredClaims
          .Select(item => AssuredClaimDTO.FromToDoItem(item))
          .ToList()
      );
    }
  }
}
