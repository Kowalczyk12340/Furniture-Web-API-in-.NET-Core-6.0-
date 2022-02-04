namespace FurnitureAPI.Models
{
  public class Order
  {
    public int IdOrder { get; set; }
    public int IdClient { get; set; }
    public virtual Client Client { get; set; }
    public int IdEmployee { get; set; }
    public virtual Employee Employee { get; set; }
    public int IdStatusOrder { get; set; }
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
