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
  public class FurnitureController : ControllerBase
  {
    private readonly IFurnitureService _furnitureService;

    public FurnitureController(IFurnitureService furnitureService)
    {
      _furnitureService = furnitureService;
    }

    /// <summary>
    /// Method to display all furnitures available in the database
    /// </summary>
    /// <returns>List of furnitures with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<FurnitureDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FurnitureDto>>> GetAll()
    {
      var furnitureDtos = await _furnitureService.GetAll();

      if (furnitureDtos is null)
      {
        return NotFound();
      }

      return Ok(furnitureDtos);
    }

    /// <summary>
    /// Method to export chosen furniture to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Furniture exist and have been successfully save to csv file</response>
    /// <response code="404">Furniture do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _furnitureService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _furnitureService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get furniture with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Furniture with chosen id</returns>
    /// <response code="200">Furniture exists and has been successfully retrieved</response>
    /// <response code="404">Furniture does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Furniture), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Furniture>> Get([FromRoute] int id)
    {
      var furniture = await _furnitureService.GetById(id);
      return Ok(furniture);
    }

    /// <summary>
    /// Method to add furniture to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created furniture</returns>
    /// <response code="201">Furniture has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(FurnitureDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FurnitureDto>> Create([FromBody] CreateFurnitureDto dto)
    {
      try
      {
        var id = await _furnitureService.Create(dto);
        return Created($"/api/Furniture/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen furniture by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full furniture</returns>
    /// <response code="200">Furniture exists and has been successfully modified</response>
    /// <response code="400">Furniture exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Furniture does not exist</response>
    [ProducesResponseType(typeof(FurnitureDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<FurnitureDto>> Update([FromBody] UpdateFurnitureDto dto, [FromRoute] int id)
    {
      await _furnitureService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen furniture with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Furniture exists and has been successfully deletes</response>
    /// <response code="400">Furniture exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Furniture does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _furnitureService.Delete(id);
      return NoContent();
    }
  }
}