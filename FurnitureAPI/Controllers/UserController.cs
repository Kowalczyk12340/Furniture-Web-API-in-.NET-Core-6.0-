using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FurnitureAPI.Services.Interfaces;
using FurnitureAPI.Dtos;
using FurnitureAPI.Models;
using System.Text;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize(Roles = "Admin")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
    {
      _userService = userService;
      _webHostEnvironment = webHostEnvironment;
    }

    /// <summary>
    /// Method to display all users available in the database
    /// </summary>
    /// <returns>List of users with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
      var userDtos = await _userService.GetAll();

      if (userDtos is null)
      {
        return NotFound();
      }

      return Ok(userDtos);
    }

    /// <summary>
    /// Method to delete chosen user with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">User exists and has been successfully deleted</response>
    /// <response code="400">User exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">User does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _userService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method, when you can edit or update chosen user
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full user</returns>
    /// <response code="200">User exists and has been successfully modified</response>
    /// <response code="400">User exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">User does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> Update([FromBody] UpdateUserDto dto, [FromRoute] int id)
    {
      await _userService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get user with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>User with chosen id</returns>
    /// <response code="200">User exists and has been successfully retrieved</response>
    /// <response code="404">User does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get([FromRoute] int id)
    {
      var user = await _userService.GetById(id);
      return Ok(user);
    }

    /// <summary>
    /// Method to export chosen Users to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Users exist and have been successfully save to csv file</response>
    /// <response code="404">Users do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _userService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _userService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to register new user
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly registered user</returns>
    /// <response code="200">User has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterDto dto)
    {
      await _userService.RegisterUser(dto);
      return Ok();
    }

    /// <summary>
    /// Method to login as user
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The user is login / not login</returns>
    /// <response code="200">User has been successfully logged in</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Login([FromBody] LoginDto dto)
    {
      string token = await _userService.GenerateJwt(dto);
      return Ok(token);
    }
  }
}