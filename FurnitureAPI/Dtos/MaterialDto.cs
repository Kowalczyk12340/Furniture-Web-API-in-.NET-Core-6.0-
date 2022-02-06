namespace FurnitureAPI.Dtos
{
  public class MaterialDto
  {
    public int MaterialId { get; set; }
    public int CategoryMaterialId { get; set; }
    public virtual CategoryMaterialDto CategoryMaterial { get; set; }
    public string MaterialName { get; set; }
    public double MaterialPrice { get; set; }
    public string MaterialUnit { get; set; }
    public int MaterialStockStatus { get; set; }
    public string MaterialDescription { get; set; }

    public string GetExportObject()
    {
      return $"{MaterialId};{CategoryMaterialId};{MaterialName};{MaterialPrice};{MaterialUnit};{MaterialStockStatus};{MaterialDescription};";
    }
  }
}
