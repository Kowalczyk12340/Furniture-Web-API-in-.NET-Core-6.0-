namespace FurnitureAPI.Models
{
  public class Material : DomainEntity
  {
    public int IdMaterial { get; set; }
    public int IdCategoryMaterial { get; set; }
    public virtual CategoryMaterial CategoryMaterial { get; set; }
    public string MaterialName { get; set; }
    public double MaterialPrice { get; set; }
    public string MaterialUnit { get; set; }
    public int MaterialStockStatus { get; set; }
    public string MaterialDescription { get; set; }
  }
}
