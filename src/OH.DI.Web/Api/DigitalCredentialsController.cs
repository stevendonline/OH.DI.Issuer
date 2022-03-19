using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Specifications;
using OH.DI.SharedKernel.Interfaces;
using OH.DI.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace OH.DI.Web.Api;

/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints
/// </summary>
public class DigitalCredentialsController : BaseApiController
{
  private readonly IRepository<DigitalCredential> _repository;
  private readonly IRepository<ToDoItem> _itemRep;

  public DigitalCredentialsController(IRepository<DigitalCredential> repository, IRepository<ToDoItem > itemRep)
  {
    _repository = repository;
    _itemRep = itemRep;
  }

  // GET: api/DigitalCredentials
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var DigitalCredentialDTOs = (await _repository.ListAsync())
        .Select(DigitalCredential => new DigitalCredentialDTO
        (
            id: DigitalCredential.Id,
            name: DigitalCredential.Name
        ))
        .ToList();

    return Ok(DigitalCredentialDTOs);
  }

  // GET: api/DigitalCredentials
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(string id)
  {
    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(id);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);
    if (DigitalCredential == null)
    {
      return NotFound();
    }

    var result = new DigitalCredentialDTO
    (
        id: DigitalCredential.Id,
        name: DigitalCredential.Name,
        items: new List<ToDoItemDTO>
        (
            DigitalCredential.Items.Select(i => ToDoItemDTO.FromToDoItem(i)).ToList()
        )
    );

    return Ok(result);
  }

  // POST: api/DigitalCredentials
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreateDigitalCredentialDTO request)
  {
    var newDigitalCredential = new DigitalCredential("1", request.Name);

    var createdDigitalCredential = await _repository.AddAsync(newDigitalCredential);

    var result = new DigitalCredentialDTO
    (
        id: createdDigitalCredential.Id,
        name: createdDigitalCredential.Name
    );
    return Ok(result);
  }

  // PATCH: api/DigitalCredentials/{DigitalCredentialId}/complete/{itemId}
  [HttpPatch("{DigitalCredentialId:int}/complete/{itemId}")]
  public async Task<IActionResult> Complete(string DigitalCredentialId, string itemId)
  {
    var DigitalCredentialSpec = new DigitalCredentialByIdWithItemsSpec(DigitalCredentialId);
    var DigitalCredential = await _repository.GetBySpecAsync(DigitalCredentialSpec);
    if (DigitalCredential == null) return NotFound("No such DigitalCredential");

    var toDoItem = DigitalCredential.Items.FirstOrDefault(item => item.Id == itemId);
    if (toDoItem == null) return NotFound("No such item.");

    toDoItem.MarkComplete();
    await _repository.UpdateAsync(DigitalCredential);

    return Ok();
  }
}
