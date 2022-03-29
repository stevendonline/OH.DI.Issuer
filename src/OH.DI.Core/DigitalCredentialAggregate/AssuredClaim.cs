using OH.DI.Core.DigitalCredentialAggregate.Events;
using OH.DI.SharedKernel;
using OH.DI.SharedKernel.Interfaces;

namespace OH.DI.Core.DigitalCredentialAggregate;

public class AssuredClaim : BaseEntity
{
  public string? Name { get; set; }
  public string? Value { get; set; }
  public string? AssuranceLevel { get; set; }
  public string? Source { get; set; }
  public string AuthenticationMethod { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;
  public bool IsDone { get; private set; }

  public string? DigitalCredentialId { get; set; }

  public void MarkComplete()
  {
    if (!IsDone)
    {
      IsDone = true;

      Events.Add(new AssuredClaimCompletedEvent(this));
    }
  }

  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Name} - {Description}";
  }
}
