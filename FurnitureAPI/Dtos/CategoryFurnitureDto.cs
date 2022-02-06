namespace FurnitureAPI.Dtos
{
  public class CategoryFurnitureDto
  {
    public int CategoryFurnitureId { get; set; }
    public string CategoryFurnitureName { get; set; }
    public string CategoryFurnitureDescription { get; set; }

    public string GetExportObject()
    {
      return $"{CategoryFurnitureId};{CategoryFurnitureName};{CategoryFurnitureDescription};";
    }
  }
}