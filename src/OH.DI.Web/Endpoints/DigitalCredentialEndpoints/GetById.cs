using Ardalis.ApiEndpoints;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<GetDigitalCredentialByIdRequest>
    .WithActionResult<GetDigtialCredentialByIdResponse>
{
  private readonly IRepository<DigitalCredential> _repository;
  private readonly IRepository<ToDoItem> _itemRep;

  public GetById(IRepository<DigitalCredential> repository, IRepository<ToDoItem> itemRep)
  {
    _repository = repository;
    _itemRep = itemRep;
  }

  [HttpGet(GetDigitalCredentialByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single DigitalCredential",
      Description = "Gets a single DigitalCredential by Id",
      OperationId = "DigitalCredentials.GetById",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult<GetDigtialCredentialByIdResponse>> HandleAsync([FromRoute] GetDigitalCredentialByIdRequest request,
      CancellationToken cancellationToken)
  {
    var spec = new DigitalCredentialByIdWithItemsSpec(request.DigitalCredentialId);
    var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var itemSpec = new ToDoItemsByIdSpec(request.DigitalCredentialId);
    var proitems = (await _itemRep.ListAsync(itemSpec)).Select(i => new ToDoItemRecord(i.Id, i.Title, i.Description, i.IsDone )).ToList();

    var response = new GetDigtialCredentialByIdResponse
    (
        id: entity.Id,
        name: entity.Name,
        items: proitems 
    );

    return Ok(response);
  }
}
