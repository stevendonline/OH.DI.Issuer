using Ardalis.ApiEndpoints;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<DigitalCredentialListResponse>
{
  private readonly IReadRepository<DigitalCredential> _repository;

  public List(IReadRepository<DigitalCredential> repository)
  {
    _repository = repository;
  }

  [HttpGet("/DigitalCredentials")]
  [SwaggerOperation(
      Summary = "Gets a list of all DigitalCredentials",
      Description = "Gets a list of all DigitalCredentials",
      OperationId = "DigitalCredential.List",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult<DigitalCredentialListResponse>> HandleAsync(CancellationToken cancellationToken)
  {
    var response = new DigitalCredentialListResponse();
    response.DigitalCredentials = (await _repository.ListAsync()) // TODO: pass cancellation token
        .Select(DigitalCredential => new DigitalCredentialRecord(DigitalCredential.Id, DigitalCredential.Name))
        .ToList();

    return Ok(response);
  }
}
