namespace FurnitureAPI.Models
{
  public class FurnitureMaterial : DomainEntity
  {
    public int FurnitureMaterialId { get; set; }
    public int FurnitureId { get; set; }
    public virtual Furniture Furniture { get; set; }
    public int MaterialId { get; set; }
    public virtual Material Material { get; set; }
    public int FurnitureMaterialAmount { get; set; }
    public double FurnitureMaterialPrice { get; set; }
    public string FurnitureMaterialDescription { get; set; }
  }
}
