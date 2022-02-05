using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Models;
using FurnitureAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FurnitureAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize(Roles = "User, Admin")]
  public class CategoryFurnitureController : ControllerBase
  {
    private readonly ICategoryFurnitureService _categoryFurnitureService;

    public CategoryFurnitureController(ICategoryFurnitureService categoryFurnitureService)
    {
      _categoryFurnitureService = categoryFurnitureService;
    }

    /// <summary>
    /// Method to display all category furnitures available in the database
    /// </summary>
    /// <returns>List of category furnitures with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<CategoryFurnitureDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryFurnitureDto>>> GetAll()
    {
      var CategoryFurnitureDtos = await _categoryFurnitureService.GetAll();

      if (CategoryFurnitureDtos is null)
      {
        return NotFound();
      }

      return Ok(CategoryFurnitureDtos);
    }

    /// <summary>
    /// Method to export chosen category furniture to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Category furniture exist and have been successfully save to csv file</response>
    /// <response code="404">Category furniture do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _categoryFurnitureService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _categoryFurnitureService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get category furniture with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Category furniture with chosen id</returns>
    /// <response code="200">Category furniture exists and has been successfully retrieved</response>
    /// <response code="404">Category furniture does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryFurniture), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryFurniture>> Get([FromRoute] int id)
    {
      var CategoryFurniture = await _categoryFurnitureService.GetById(id);
      return Ok(CategoryFurniture);
    }

    /// <summary>
    /// Method to add category furniture to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created category furniture</returns>
    /// <response code="201">Category furniture has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryFurnitureDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryFurnitureDto>> Create([FromBody] CreateCategoryFurnitureDto dto)
    {
      try
      {
        var id = await _categoryFurnitureService.Create(dto);
        return Created($"/api/CategoryFurniture/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen category furniture by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full category furniture</returns>
    /// <response code="200">Category furniture exists and has been successfully modified</response>
    /// <response code="400">Category furniture exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Category furniture does not exist</response>
    [ProducesResponseType(typeof(CategoryFurnitureDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryFurnitureDto>> Update([FromBody] UpdateCategoryFurnitureDto dto, [FromRoute] int id)
    {
      await _categoryFurnitureService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen category furniture with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Category furniture exists and has been successfully deletes</response>
    /// <response code="400">Category furniture exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Category furniture does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _categoryFurnitureService.Delete(id);
      return NoContent();
    }
  }
}