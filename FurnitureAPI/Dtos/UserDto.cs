namespace FurnitureAPI.Dtos
{
  public class UserDto
  {
    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Login { get; set; }
    public string RoleName { get; set; }
    public string Password { get; set; }
    public string Nationality { get; set; }

    public string GetExportObject()
    {
      return $"{UserId};{UserFirstName};{LastName};{IsActive};{DateOfBirth}{Login};{Nationality};{RoleName}";
    }
  }
}
