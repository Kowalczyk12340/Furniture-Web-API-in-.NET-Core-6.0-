namespace FurnitureAPI.Models
{
  public class FileModel : DomainEntity
  {
    public string FileName { get; set; }
    public IFormFile FormFile { get; set; }
  }
}