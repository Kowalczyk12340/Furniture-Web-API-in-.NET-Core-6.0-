namespace FurnitureAPI.Models
{
  public class StatusOrder : DomainEntity
  {
    public int IdStatusOrder { get; set; }
    public string StatusOrderName { get; set; }
    public string StatusOrderDescription { get; set; }
  }
}
