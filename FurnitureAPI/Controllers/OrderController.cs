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
  public class OrderController : ControllerBase
  {
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    /// <summary>
    /// Method to display all orders available in the database
    /// </summary>
    /// <returns>List of orders with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
      var orderDtos = await _orderService.GetAll();

      if (orderDtos is null)
      {
        return NotFound();
      }

      return Ok(orderDtos);
    }

    /// <summary>
    /// Method to export chosen order to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Order exist and have been successfully save to csv file</response>
    /// <response code="404">Order do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _orderService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _orderService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get order with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Order with chosen id</returns>
    /// <response code="200">Order exists and has been successfully retrieved</response>
    /// <response code="404">Order does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> Get([FromRoute] int id)
    {
      var order = await _orderService.GetById(id);
      return Ok(order);
    }

    /// <summary>
    /// Method to add order to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created order</returns>
    /// <response code="201">Order has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderDto dto)
    {
      try
      {
        var id = await _orderService.Create(dto);
        return Created($"/api/Order/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen order by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full order</returns>
    /// <response code="200">Order exists and has been successfully modified</response>
    /// <response code="400">Order exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Order does not exist</response>
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<OrderDto>> Update([FromBody] UpdateOrderDto dto, [FromRoute] int id)
    {
      await _orderService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen order with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Order exists and has been successfully deletes</response>
    /// <response code="400">Order exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Order does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _orderService.Delete(id);
      return NoContent();
    }
  }
}