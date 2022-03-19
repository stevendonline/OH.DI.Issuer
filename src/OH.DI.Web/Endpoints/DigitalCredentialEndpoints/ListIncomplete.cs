using Ardalis.ApiEndpoints;
using OH.DI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class ListIncomplete : EndpointBaseAsync
    .WithRequest<ListIncompleteRequest>
    .WithActionResult<ListIncompleteResponse>
{
  private readonly IToDoItemSearchService _searchService;

  public ListIncomplete(IToDoItemSearchService searchService)
  {
    _searchService = searchService;
  }

  [HttpGet("/DigitalCredentials/{DigitalCredentialId}/IncompleteItems")]
  [SwaggerOperation(
      Summary = "Gets a list of a digital credential's incomplete items",
      Description = "Gets a list of a digital credential's incomplete items",
      OperationId = "DigitalCredential.ListIncomplete",
      Tags = new[] { "DigitalCredentialEndpoints" })
  ]
  public override async Task<ActionResult<ListIncompleteResponse>> HandleAsync([FromQuery] ListIncompleteRequest request, CancellationToken cancellationToken)
  {
    if (request.SearchString == null)
    {
      return BadRequest();
    }
    var response = new ListIncompleteResponse(1.ToString(), new List<ToDoItemRecord>());
    var result = await _searchService.GetAllIncompleteItemsAsync(request.DigitalCredentialId, request.SearchString);

    if (result.Status == Ardalis.Result.ResultStatus.Ok)
    {
      response.DigitalCredentialId = request.DigitalCredentialId;
      response.IncompleteItems = new List<ToDoItemRecord>(
              result.Value.Select(
                  item => new ToDoItemRecord(item.Id,
                  item.Title,
                  item.Description,
                  item.IsDone)));
    }
    else if (result.Status == Ardalis.Result.ResultStatus.Invalid)
    {
      return BadRequest(result.ValidationErrors);
    }
    else if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      return NotFound();
    }

    return Ok(response);
  }
}
