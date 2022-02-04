namespace FurnitureAPI.Dtos.Update
{
  public class UpdateOrderDto
  {
    public string OrderCode { get; set; }
    public DateTime OrderDateSubmission { get; set; }
    public DateTime OrderDateRealization { get; set; }
    public DateTime OrderDeadlineRealization { get; set; }
    public double OrderPrePayment { get; set; }
    public double OrderPayment { get; set; }
    public string OrderInfo { get; set; }
    public int IdClient { get; set; }
    public int IdEmployee { get; set; }
    public int IdStatusOrder { get; set; }
  }
}
