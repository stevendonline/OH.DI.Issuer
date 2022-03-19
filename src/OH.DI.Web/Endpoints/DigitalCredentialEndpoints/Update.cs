using Ardalis.ApiEndpoints;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateDigitalCredentialRequest>
    .WithActionResult<UpdateDigitalCredentialResponse>
{
  private readonly IRepository<DigitalCredential> _repository;

  public Update(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdateDigitalCredentialRequest.Route)]
  [SwaggerOperation(
      Summary = "Updates a DigitalCredential",
      Description = "Updates a DigitalCredential with a longer description",
      OperationId = "DigitalCredentials.Update",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult<UpdateDigitalCredentialResponse>> HandleAsync(UpdateDigitalCredentialRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }
    var existingDigitalCredential = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

    if (existingDigitalCredential == null)
    {
      return NotFound();
    }
    existingDigitalCredential.UpdateName(request.Name);

    await _repository.UpdateAsync(existingDigitalCredential); // TODO: pass cancellation token

    var response = new UpdateDigitalCredentialResponse(
        DigitalCredential: new DigitalCredentialRecord(existingDigitalCredential.Id, existingDigitalCredential.Name)
    );
    return Ok(response);
  }
}
