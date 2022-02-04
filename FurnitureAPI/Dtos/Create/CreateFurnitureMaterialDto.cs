namespace FurnitureAPI.Dtos.Create
{
  public class CreateFurnitureMaterialDto
  {
    public int FurnitureMaterialAmount { get; set; }
    public double FurnitureMaterialPrice { get; set; }
    public string FurnitureMaterialDescription { get; set; }
    public int IdFurniture { get; set; }
    public int IdMaterial { get; set; }
  }
}
