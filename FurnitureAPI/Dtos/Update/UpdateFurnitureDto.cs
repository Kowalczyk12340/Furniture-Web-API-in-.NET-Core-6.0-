namespace FurnitureAPI.Dtos.Update
{
  public class UpdateFurnitureDto
  {
    public string FurnitureName { get; set; }
    public double FurniturePrice { get; set; }
    public string FurnitureUnit { get; set; }
    public double FurnitureWidth { get; set; }
    public double FurnitureHeight { get; set; }
    public double FurnitureDepth { get; set; }
    public string FurnitureDescription { get; set; }
    public int IdOrder { get; set; }
    public int IdCategoryFurniture { get; set; }
  }
}
