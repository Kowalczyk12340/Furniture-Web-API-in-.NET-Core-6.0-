namespace FurnitureAPI.Dtos
{
  public class StatusOrderDto
  {
    public int StatusOrderId { get; set; }
    public string StatusOrderName { get; set; }
    public string StatusOrderDescription { get; set; }

    public string GetExportObject()
    {
      return $"{StatusOrderId};{StatusOrderName};{StatusOrderDescription};";
    }
  }
}