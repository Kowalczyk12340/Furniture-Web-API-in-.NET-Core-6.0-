namespace FurnitureAPI.Dtos
{
  public class MaterialDto
  {
    public int IdMaterial { get; set; }
    public int IdCategoryMaterial { get; set; }
    public virtual CategoryMaterialDto CategoryMaterial { get; set; }
    public string MaterialName { get; set; }
    public double MaterialPrice { get; set; }
    public string MaterialUnit { get; set; }
    public int MaterialStockStatus { get; set; }
    public string MaterialDescription { get; set; }

    public string GetExportObject()
    {
      return $"{IdMaterial};{IdCategoryMaterial};{MaterialName};{MaterialPrice};{MaterialUnit};{MaterialStockStatus};{MaterialDescription};";
    }
  }
}
