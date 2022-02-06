namespace FurnitureAPI.Models
{
  public class Order : DomainEntity
  {
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public int StatusOrderId { get; set; }
    public virtual StatusOrder StatusOrder { get; set; }
    public string OrderCode { get; set; }
    public DateTime OrderDateSubmission { get; set; }
    public DateTime OrderDateRealization { get; set; }
    public DateTime OrderDeadlineRealization { get; set; }
    public double OrderPrePayment { get; set; }
    public double OrderPayment { get; set; }
    public string OrderInfo { get; set; }
  }
}
