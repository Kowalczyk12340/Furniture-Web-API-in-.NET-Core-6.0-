namespace FurnitureAPI.Dtos
{
  public class FurnitureMaterialDto
  {
    public int FurnitureMaterialId { get; set; }
    public int FurnitureId { get; set; }
    public virtual FurnitureDto Furniture { get; set; }
    public int MaterialId { get; set; }
    public virtual MaterialDto Material { get; set; }
    public int FurnitureMaterialAmount { get; set; }
    public double FurnitureMaterialPrice { get; set; }
    public string FurnitureMaterialDescription { get; set; }

    public string GetExportObject()
    {
      return $"{FurnitureMaterialId};{FurnitureId};{MaterialId};{FurnitureMaterialAmount};{FurnitureMaterialPrice};{FurnitureMaterialDescription};";
    }
  }
}
