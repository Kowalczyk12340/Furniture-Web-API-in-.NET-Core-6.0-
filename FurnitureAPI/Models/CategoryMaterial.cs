﻿namespace FurnitureAPI.Models
{
  public class CategoryMaterial : DomainEntity
  {
    public int IdCategoryMaterial { get; set; }
    public string CategoryMaterialName { get; set; }
    public string CategoryMaterialDescription { get; set; }
  }
}
