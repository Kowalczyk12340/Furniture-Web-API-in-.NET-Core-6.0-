namespace FurnitureAPI.Models
{
  public class StatusOrder : DomainEntity
  {
    public int StatusOrderId { get; set; }
    public string StatusOrderName { get; set; }
    public string StatusOrderDescription { get; set; }
  }
}
