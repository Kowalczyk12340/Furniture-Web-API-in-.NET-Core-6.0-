namespace FurnitureAPI.Models
{
  public class CategoryFurniture : DomainEntity
  {
    public int IdCategoryFurniture { get; set; }
    public string CategoryFurnitureName { get; set; }
    public string CategoryFurnitureDescription { get; set; }
  }
}