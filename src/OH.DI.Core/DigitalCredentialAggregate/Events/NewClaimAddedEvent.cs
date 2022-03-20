using OH.DI.SharedKernel;

namespace OH.DI.Core.DigitalCredentialAggregate.Events;

public class NewClaimAddedEvent : BaseDomainEvent
{
  public AssuredClaim NewClaim { get; set; }
  public DigitalCredential DigtialCred { get; set; }

  public NewClaimAddedEvent(DigitalCredential cred,
      AssuredClaim newItem)
  {
    DigtialCred = cred;
    NewClaim = newItem;
  }
}
