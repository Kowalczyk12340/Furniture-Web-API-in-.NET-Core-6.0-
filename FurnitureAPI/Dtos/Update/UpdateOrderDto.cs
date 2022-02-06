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
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }
    public int StatusOrderId { get; set; }
  }
}
