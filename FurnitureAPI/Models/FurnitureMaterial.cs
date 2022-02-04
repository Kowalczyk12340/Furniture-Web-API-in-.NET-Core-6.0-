namespace FurnitureAPI.Models
{
  public class FurnitureMaterial
  {
    public int IdFurnitureMaterial { get; set; }
    public int IdFurniture { get; set; }
    public virtual Furniture Furniture { get; set; }
    public int IdMaterial { get; set; }
    public virtual Material Material { get; set; }
    public int FurnitureMaterialAmount { get; set; }
    public double FurnitureMaterialPrice { get; set; }
    public string FurnitureMaterialDescription { get; set; }
  }
}
