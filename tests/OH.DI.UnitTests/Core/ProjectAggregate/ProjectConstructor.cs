using OH.DI.Core.DigitalCredentialAggregate;
using Xunit;

namespace OH.DI.UnitTests.Core.DigitalCredentialAggregate;

public class DigitalCredentialConstructor
{
  private string _testName = "test name";
  private DigitalCredential? _testDigitalCredential;

  private DigitalCredential CreateDigitalCredential()
  {
    return new DigitalCredential("1", _testName);
  }

  [Fact]
  public void InitializesName()
  {
    _testDigitalCredential = CreateDigitalCredential();

    Assert.Equal(_testName, _testDigitalCredential.Name);
  }

  [Fact]
  public void InitializesTaskListToEmptyList()
  {
    _testDigitalCredential = CreateDigitalCredential();

    Assert.NotNull(_testDigitalCredential.AssuredClaims);
  }

  [Fact]
  public void InitializesStatusToInProgress()
  {
    _testDigitalCredential = CreateDigitalCredential();

    Assert.Equal(DigitalCredentialStatus.Complete, _testDigitalCredential.Status);
  }
}
