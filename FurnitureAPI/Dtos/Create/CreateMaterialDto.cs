namespace FurnitureAPI.Dtos.Create
{
  public class CreateMaterialDto
  {
    public string MaterialName { get; set; }
    public double MaterialPrice { get; set; }
    public string MaterialUnit { get; set; }
    public int MaterialStockStatus { get; set; }
    public string MaterialDescription { get; set; }
    public int CategoryMaterialId { get; set; }
  }
}
