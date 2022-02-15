using Ardalis.Specification;
using OH.DI.Core.ProjectAggregate;

namespace OH.DI.Core.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(string projectId)
  {
    Query
        .Where(project => project.Id == projectId);
        //.Include(project => project.Items);
  }
}
