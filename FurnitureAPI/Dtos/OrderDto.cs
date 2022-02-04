namespace FurnitureAPI.Dtos
{
  public class OrderDto
  {
    public int IdOrder { get; set; }
    public int IdClient { get; set; }
    public virtual ClientDto Client { get; set; }
    public int IdEmployee { get; set; }
    public virtual EmployeeDto Employee { get; set; }
    public int IdStatusOrder { get; set; }
    public virtual StatusOrderDto StatusOrder { get; set; }
    public string OrderCode { get; set; }
    public DateTime OrderDateSubmission { get; set; }
    public DateTime OrderDateRealization { get; set; }
    public DateTime OrderDeadlineRealization { get; set; }
    public double OrderPrePayment { get; set; }
    public double OrderPayment { get; set; }
    public string OrderInfo { get; set; }
  }
}
