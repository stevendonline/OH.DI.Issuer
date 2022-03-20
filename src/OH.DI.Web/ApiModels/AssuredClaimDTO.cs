using System.ComponentModel.DataAnnotations;
using OH.DI.Core.DigitalCredentialAggregate;

namespace OH.DI.Web.ApiModels;

// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
public class AssuredClaimDTO
{
  public string Id { get; set; }
  [Required]
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool IsDone { get; private set; }

  public static AssuredClaimDTO FromToDoItem(AssuredClaim item)
  {
    return new AssuredClaimDTO()
    {
      Id = item.Id,
      Title = item.Name,
      Description = item.Description,
      IsDone = item.IsDone
    };
  }
}
