using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using FurnitureAPI.Models;

namespace FurnitureAPI.Controllers
{
  [Route("file")]
  public class FileController : ControllerBase
  {
    /// <summary>
    /// Method to get file
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The photo is added / not added</returns>
    /// <response code="200">File has been successfully found</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ResponseCache(Duration = 1200, VaryByQueryKeys = new[] { "fileName" })]
    [HttpGet]
    public ActionResult GetFile([FromQuery] string fileName)
    {
      var rootPath = Directory.GetCurrentDirectory();
      var filePath = $"{rootPath}/PrivateFiles/{fileName}";
      var fileExists = System.IO.File.Exists(filePath);

      if(!fileExists)
      {
        return NotFound();
      }

      var contentProvider = new FileExtensionContentTypeProvider();
      contentProvider.TryGetContentType(fileName, out string contentType);

      var fileContents = System.IO.File.ReadAllBytes(filePath);

      return File(fileContents, contentType, fileName);
    }

    /// <summary>
    /// Method to upload file
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The file is added / not added</returns>
    /// <response code="200">File has been successfully uploaded</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(File), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public ActionResult Upload([FromForm] FileModel fileModel)
    {
      try
      {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "PrivateFiles", fileModel.FileName);

        using(Stream stream = new FileStream(path, FileMode.Create))
        {
          fileModel.FormFile.CopyTo(stream);
        }

        return StatusCode(StatusCodes.Status201Created);
      }
      catch(Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}