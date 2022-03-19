using Ardalis.ApiEndpoints;
using OH.DI.Core.ProjectAggregate;
using OH.DI.Core.ProjectAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace OH.DI.Web.Endpoints.ProjectEndpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<GetProjectByIdRequest>
    .WithActionResult<GetProjectByIdResponse>
{
  private readonly IRepository<DigitalCredential> _repository;
  private readonly IRepository<ToDoItem> _itemRep;

  public GetById(IRepository<DigitalCredential> repository, IRepository<ToDoItem> itemRep)
  {
    _repository = repository;
    _itemRep = itemRep;
  }

  [HttpGet(GetProjectByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single Project",
      Description = "Gets a single Project by Id",
      OperationId = "Projects.GetById",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync([FromRoute] GetProjectByIdRequest request,
      CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var itemSpec = new ToDoItemsByIdSpec(request.ProjectId);
    var proitems = (await _itemRep.ListAsync(itemSpec)).Select(i => new ToDoItemRecord(i.Id, i.Title, i.Description, i.IsDone )).ToList();

    var response = new GetProjectByIdResponse
    (
        id: entity.Id,
        name: entity.Name,
        items: proitems 
    );

    return Ok(response);
  }
}
