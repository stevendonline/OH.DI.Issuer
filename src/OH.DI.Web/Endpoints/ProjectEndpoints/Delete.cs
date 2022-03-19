using Ardalis.ApiEndpoints;
using OH.DI.Core.ProjectAggregate;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteProjectRequest>
    .WithoutResult
{
  private readonly IRepository<DigitalCredential> _repository;

  public Delete(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteProjectRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Project",
      Description = "Deletes a Project",
      OperationId = "Projects.Delete",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteProjectRequest request,
      CancellationToken cancellationToken)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId); // TODO: pass cancellation token
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete);

    return NoContent();
  }
}
