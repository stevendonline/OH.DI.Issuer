using Ardalis.ApiEndpoints;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteDigitalCredentialRequest>
    .WithoutResult
{
  private readonly IRepository<DigitalCredential> _repository;

  public Delete(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteDigitalCredentialRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a DigitalCredential",
      Description = "Deletes a DigitalCredential",
      OperationId = "DigitalCredential.Delete",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteDigitalCredentialRequest request,
      CancellationToken cancellationToken)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.DigitalCredentialId); // TODO: pass cancellation token
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete);

    return NoContent();
  }
}
