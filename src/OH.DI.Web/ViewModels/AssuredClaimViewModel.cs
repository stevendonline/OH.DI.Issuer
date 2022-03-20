using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Web.ViewModels;

public class AssuredClaimViewModel
{
  public string Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool IsDone { get; private set; }

  public static AssuredClaimViewModel FromToDoItem(AssuredClaim item)
  {
    return new AssuredClaimViewModel()
    {
      Id = item.Id,
      Title = item.Name,
      Description = item.Description,
      IsDone = item.IsDone
    };
  }
}
