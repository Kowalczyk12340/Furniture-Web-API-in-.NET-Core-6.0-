using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FurnitureAPI.Services.Interfaces;
using System.Text;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Models;

namespace FurnitureAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize(Roles = "User, Admin")]
  public class ClientController : ControllerBase
  {
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
      _clientService = clientService;
    }

    /// <summary>
    /// Method to display all clients available in the database
    /// </summary>
    /// <returns>List of clients with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<ClientDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
    {
      var clientDtos = await _clientService.GetAll();

      if (clientDtos is null)
      {
        return NotFound();
      }

      return Ok(clientDtos);
    }

    /// <summary>
    /// Method to export chosen client to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Client exist and have been successfully save to csv file</response>
    /// <response code="404">Client do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _clientService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _clientService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get client with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Client with chosen id</returns>
    /// <response code="200">Client exists and has been successfully retrieved</response>
    /// <response code="404">Client does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Client>> Get([FromRoute] int id)
    {
      var client = await _clientService.GetById(id);
      return Ok(client);
    }

    /// <summary>
    /// Method to add client to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created client</returns>
    /// <response code="201">Client has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Create([FromBody] CreateClientDto dto)
    {
      try
      {
        var id = await _clientService.Create(dto);
        return Created($"/api/Client/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen client by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full client</returns>
    /// <response code="200">Client exists and has been successfully modified</response>
    /// <response code="400">Client exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Client does not exist</response>
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ClientDto>> Update([FromBody] UpdateClientDto dto, [FromRoute] int id)
    {
      await _clientService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen client with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Client exists and has been successfully deletes</response>
    /// <response code="400">Client exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Client does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _clientService.Delete(id);
      return NoContent();
    }
  }
}