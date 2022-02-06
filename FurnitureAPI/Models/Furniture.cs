namespace FurnitureAPI.Models
{
  public class Furniture : DomainEntity
  {
    public int FurnitureId { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int CategoryFurnitureId { get; set; }
    public virtual CategoryFurniture CategoryFurniture { get; set; }
    public string FurnitureName { get; set; }
    public double FurniturePrice { get; set; }
    public string FurnitureUnit { get; set; }
    public double FurnitureWidth { get; set; }
    public double FurnitureHeight { get; set; }
    public double FurnitureDepth { get; set; }
    public string FurnitureDescription { get; set; }
  }
}
