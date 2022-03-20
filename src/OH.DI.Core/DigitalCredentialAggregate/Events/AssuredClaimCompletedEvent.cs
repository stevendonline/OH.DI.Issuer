using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel;

namespace OH.DI.Core.DigitalCredentialAggregate.Events;

public class AssuredClaimCompletedEvent : BaseDomainEvent
{
  public AssuredClaim CompletedClaim { get; set; }

  public AssuredClaimCompletedEvent(AssuredClaim completedClaim)
  {
    CompletedClaim = completedClaim;
  }
}
