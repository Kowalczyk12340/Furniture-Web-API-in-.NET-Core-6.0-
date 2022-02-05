namespace FurnitureAPI.Dtos
{
  public class CategoryMaterialDto
  {
    public int IdCategoryMaterial { get; set; }
    public string CategoryMaterialName { get; set; }
    public string CategoryMaterialDescription { get; set; }

    public string GetExportObject()
    {
      return $"{IdCategoryMaterial};{CategoryMaterialName};{CategoryMaterialDescription};";
    }
  }
}
