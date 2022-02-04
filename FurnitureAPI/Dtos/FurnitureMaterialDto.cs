namespace FurnitureAPI.Dtos
{
  public class FurnitureMaterialDto
  {
    public int IdFurnitureMaterial { get; set; }
    public int IdFurniture { get; set; }
    public virtual FurnitureDto Furniture { get; set; }
    public int IdMaterial { get; set; }
    public virtual MaterialDto Material { get; set; }
    public int FurnitureMaterialAmount { get; set; }
    public double FurnitureMaterialPrice { get; set; }
    public string FurnitureMaterialDescription { get; set; }
  }
}
