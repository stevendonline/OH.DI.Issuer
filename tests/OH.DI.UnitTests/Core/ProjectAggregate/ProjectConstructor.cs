using OH.DI.Core.ProjectAggregate;
using Xunit;

namespace OH.DI.UnitTests.Core.ProjectAggregate;

public class DigitalCredentialConstructor
{
  private string _testName = "test name";
  private DigitalCredential? _testProject;

  private DigitalCredential CreateProject()
  {
    return new DigitalCredential("1", _testName);
  }

  [Fact]
  public void InitializesName()
  {
    _testProject = CreateProject();

    Assert.Equal(_testName, _testProject.Name);
  }

  [Fact]
  public void InitializesTaskListToEmptyList()
  {
    _testProject = CreateProject();

    Assert.NotNull(_testProject.Items);
  }

  [Fact]
  public void InitializesStatusToInProgress()
  {
    _testProject = CreateProject();

    Assert.Equal(DigitalCredentialStatus.Complete, _testProject.Status);
  }
}
