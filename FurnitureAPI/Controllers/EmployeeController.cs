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
  public class EmployeeController : ControllerBase
  {
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    /// <summary>
    /// Method to display all employees available in the database
    /// </summary>
    /// <returns>List of employees with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
      var employeeDtos = await _employeeService.GetAll();

      if (employeeDtos is null)
      {
        return NotFound();
      }

      return Ok(employeeDtos);
    }

    /// <summary>
    /// Method to export chosen employee to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Employee exist and have been successfully save to csv file</response>
    /// <response code="404">Employee do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _employeeService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _employeeService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get employee with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Employee with chosen id</returns>
    /// <response code="200">Employee exists and has been successfully retrieved</response>
    /// <response code="404">Employee does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Employee>> Get([FromRoute] int id)
    {
      var employee = await _employeeService.GetById(id);
      return Ok(employee);
    }

    /// <summary>
    /// Method to add employee to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created employee</returns>
    /// <response code="201">Employee has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmployeeDto>> Create([FromBody] CreateEmployeeDto dto)
    {
      try
      {
        var id = await _employeeService.Create(dto);
        return Created($"/api/Employee/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen employee by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full employee</returns>
    /// <response code="200">Employee exists and has been successfully modified</response>
    /// <response code="400">Employee exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Employee does not exist</response>
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeDto>> Update([FromBody] UpdateEmployeeDto dto, [FromRoute] int id)
    {
      await _employeeService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to delete chosen employee with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Employee exists and has been successfully deletes</response>
    /// <response code="400">Employee exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Employee does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _employeeService.Delete(id);
      return NoContent();
    }
  }
}