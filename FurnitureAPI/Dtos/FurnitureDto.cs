namespace FurnitureAPI.Dtos
{
  public class FurnitureDto
  {
    public int IdFurniture { get; set; }
    public int IdOrder { get; set; }
    public virtual OrderDto Order { get; set; }
    public int IdCategoryFurniture { get; set; }
    public virtual CategoryFurnitureDto CategoryFurniture { get; set; }
    public string FurnitureName { get; set; }
    public double FurniturePrice { get; set; }
    public string FurnitureUnit { get; set; }
    public double FurnitureWidth { get; set; }
    public double FurnitureHeight { get; set; }
    public double FurnitureDepth { get; set; }
    public string FurnitureDescription { get; set; }
  }
}
