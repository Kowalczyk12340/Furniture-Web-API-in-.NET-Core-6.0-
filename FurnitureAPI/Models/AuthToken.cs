﻿namespace FurnitureAPI.Models
{
  public class AuthToken : DomainEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}
