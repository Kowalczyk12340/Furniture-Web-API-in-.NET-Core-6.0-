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
  public class MaterialController : ControllerBase
  {
    private readonly IMaterialService _materialService;

    public MaterialController(IMaterialService materialService)
    {
      _materialService = materialService;
    }

    /// <summary>
    /// Method to display all materials available in the database
    /// </summary>
    /// <returns>List of materials with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<MaterialDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
    {
      var materialDtos = await _materialService.GetAll();

      if (materialDtos is null)
      {
        return NotFound();
      }

      return Ok(materialDtos);
    }

    /// <summary>
    /// Method to export chosen material to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Material exist and have been successfully save to csv file</response>
    /// <response code="404">Material do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _materialService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _materialService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get material with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Material with chosen id</returns>
    /// <response code="200">Material exists and has been successfully retrieved</response>
    /// <response code="404">Material does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Material), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Material>> Get([FromRoute] int id)
    {
      var material = await _materialService.GetById(id);
      return Ok(material);
    }

    /// <summary>
    /// Method to add material to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created material</returns>
    /// <response code="201">Material has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(MaterialDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaterialDto>> Create([FromBody] CreateMaterialDto dto)
    {
      try
      {
        var id = await _materialService.Create(dto);
        return Created($"/api/Material/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen material by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full material</returns>
    /// <response code="200">Material exists and has been successfully modified</response>
    /// <response code="400">Material exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Material does not exist</response>
    [ProducesResponseType(typeof(MaterialDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<MaterialDto>> Update([FromBody] UpdateMaterialDto dto, [FromRoute] int id)
    {
      await _materialService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen material with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Material exists and has been successfully deletes</response>
    /// <response code="400">Material exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Material does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _materialService.Delete(id);
      return NoContent();
    }
  }
}