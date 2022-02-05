namespace FurnitureAPI.Dtos
{
  public class StatusOrderDto
  {
    public int IdStatusOrder { get; set; }
    public string StatusOrderName { get; set; }
    public string StatusOrderDescription { get; set; }

    public string GetExportObject()
    {
      return $"{IdStatusOrder};{StatusOrderName};{StatusOrderDescription};";
    }
  }
}