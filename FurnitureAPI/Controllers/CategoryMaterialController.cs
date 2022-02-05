using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
  public class CategoryMaterialController : ControllerBase
  {
    private readonly ICategoryMaterialService _categoryMaterialService;

    public CategoryMaterialController(ICategoryMaterialService categoryMaterialService)
    {
      _categoryMaterialService = categoryMaterialService;
    }

    /// <summary>
    /// Method to display all category materials available in the database
    /// </summary>
    /// <returns>List of category materials with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<CategoryMaterialDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryMaterialDto>>> GetAll()
    {
      var categoryMaterialDtos = await _categoryMaterialService.GetAll();

      if (categoryMaterialDtos is null)
      {
        return NotFound();
      }

      return Ok(categoryMaterialDtos);
    }

    /// <summary>
    /// Method to export chosen category Material to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Category Material exist and have been successfully save to csv file</response>
    /// <response code="404">Category Material do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _categoryMaterialService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _categoryMaterialService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get category material with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Category Material with chosen id</returns>
    /// <response code="200">Category Material exists and has been successfully retrieved</response>
    /// <response code="404">Category Material does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryMaterial), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryMaterial>> Get([FromRoute] int id)
    {
      var categoryMaterial = await _categoryMaterialService.GetById(id);
      return Ok(categoryMaterial);
    }

    /// <summary>
    /// Method to add category material to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created category material</returns>
    /// <response code="201">Category Material has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryMaterialDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryMaterialDto>> Create([FromBody] CreateCategoryMaterialDto dto)
    {
      try
      {
        var id = await _categoryMaterialService.Create(dto);
        return Created($"/api/CategoryMaterial/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen category material by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full category material</returns>
    /// <response code="200">Category Material exists and has been successfully modified</response>
    /// <response code="400">Category Material exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Category Material does not exist</response>
    [ProducesResponseType(typeof(CategoryMaterialDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryMaterialDto>> Update([FromBody] UpdateCategoryMaterialDto dto, [FromRoute] int id)
    {
      await _categoryMaterialService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen category material with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Category material exists and has been successfully deletes</response>
    /// <response code="400">Category material exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Category material does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _categoryMaterialService.Delete(id);
      return NoContent();
    }
  }
}
