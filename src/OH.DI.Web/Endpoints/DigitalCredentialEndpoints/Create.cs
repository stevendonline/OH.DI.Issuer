using Ardalis.ApiEndpoints;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class Create : EndpointBaseAsync
    .WithRequest<CreateDigitalCredentialRequest>
    .WithActionResult<CreateDigitalCredentialResponse>
{
  private readonly IRepository<DigitalCredential> _repository;

  public Create(IRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  [HttpPost("/DigitalCredentials")]
  [SwaggerOperation(
      Summary = "Creates a new Digital Credential",
      Description = "Creates a new Digital Credential",
      OperationId = "DigitalCredential.Create",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult<CreateDigitalCredentialResponse>> HandleAsync(CreateDigitalCredentialRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newDigitalCredential = new DigitalCredential("1", request.Name);

    var createdItem = await _repository.AddAsync(newDigitalCredential); // TODO: pass cancellation token

    var response = new CreateDigitalCredentialResponse
    (
        id: createdItem.Id,
        name: createdItem.Name
    );

    return Ok(response);
  }
}
