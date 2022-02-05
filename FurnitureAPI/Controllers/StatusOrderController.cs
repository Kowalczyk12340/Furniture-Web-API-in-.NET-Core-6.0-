using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FurnitureAPI.Services.Interfaces;
using FurnitureAPI.Dtos;
using System.Text;
using FurnitureAPI.Models;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize(Roles = "User, Admin")]
  public class StatusOrderController : ControllerBase
  {
    private readonly IOrderStatusService _orderStatusService;

    /// <summary>
    /// Constructor for StatusOrderController with orderStatusService added with Dependency Injection
    /// </summary>
    /// <param name="orderStatusService"></param>
    public StatusOrderController(IOrderStatusService orderStatusService)
    {
      _orderStatusService = orderStatusService;
    }

    /// <summary>
    /// Method to display all status orders available in the database
    /// </summary>
    /// <returns>List of status orders with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<StatusOrderDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusOrderDto>>> GetAll()
    {
      var statusOrderDtos = await _orderStatusService.GetAll();
      
      if(statusOrderDtos is null)
      {
        return NotFound();
      }

      return Ok(statusOrderDtos);
    }

    /// <summary>
    /// Method to export chosen status order to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Status order exist and have been successfully save to csv file</response>
    /// <response code="404">Status order do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _orderStatusService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _orderStatusService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get status order with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status Order with chosen id</returns>
    /// <response code="200">Status Order exists and has been successfully retrieved</response>
    /// <response code="404">Status Order does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(StatusOrder), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StatusOrder>> Get([FromRoute] int id)
    {
      var statusOrder = await _orderStatusService.GetById(id);
      return Ok(statusOrder);
    }

    /// <summary>
    /// Method to add status order to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created status order</returns>
    /// <response code="201">Status order has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(StatusOrderDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StatusOrderDto>> Create([FromBody] CreateStatusOrderDto dto)
    {
      try
      {
        var id = await _orderStatusService.Create(dto);
        return Created($"/api/StatusOrder/{id}", null);
      }
      catch(BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen status order by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full status order</returns>
    /// <response code="200">Status order exists and has been successfully modified</response>
    /// <response code="400">Status order exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Status order does not exist</response>
    [ProducesResponseType(typeof(StatusOrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<StatusOrderDto>> Update([FromBody] UpdateStatusOrderDto dto, [FromRoute] int id)
    {
      await _orderStatusService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen status order with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Status Order exists and has been successfully deletes</response>
    /// <response code="400">Status Order exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Status Order does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _orderStatusService.Delete(id);
      return NoContent();
    }
  }
}
