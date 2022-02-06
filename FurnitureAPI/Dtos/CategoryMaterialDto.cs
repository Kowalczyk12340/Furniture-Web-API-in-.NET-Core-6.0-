namespace FurnitureAPI.Dtos
{
  public class CategoryMaterialDto
  {
    public int CategoryMaterialId { get; set; }
    public string CategoryMaterialName { get; set; }
    public string CategoryMaterialDescription { get; set; }

    public string GetExportObject()
    {
      return $"{CategoryMaterialId};{CategoryMaterialName};{CategoryMaterialDescription};";
    }
  }
}
