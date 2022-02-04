namespace FurnitureAPI.Dtos.Update
{
  public class UpdateUserDto
  {
    public string UserFirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Login { get; set; }
    public int IdRole { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Nationality { get; set; }
  }
}
