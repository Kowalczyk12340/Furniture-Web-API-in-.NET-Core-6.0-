﻿namespace FurnitureAPI.Dtos
{
  public class RegisterDto
  {
    public string Login { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public long RoleId { get; set; }
  }
}
