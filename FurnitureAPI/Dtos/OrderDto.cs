namespace FurnitureAPI.Dtos
{
  public class OrderDto
  {
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public virtual ClientDto Client { get; set; }
    public int EmployeeId { get; set; }
    public virtual EmployeeDto Employee { get; set; }
    public int StatusOrderId { get; set; }
    public virtual StatusOrderDto StatusOrder { get; set; }
    public string OrderCode { get; set; }
    public DateTime OrderDateSubmission { get; set; }
    public DateTime OrderDateRealization { get; set; }
    public DateTime OrderDeadlineRealization { get; set; }
    public double OrderPrePayment { get; set; }
    public double OrderPayment { get; set; }
    public string OrderInfo { get; set; }

    public string GetExportObject()
    {
      return $"{OrderId};{ClientId};{EmployeeId};{StatusOrderId};{OrderCode};{OrderDateSubmission};{OrderDateRealization};{OrderDeadlineRealization};{OrderPrePayment};{OrderPayment};{OrderInfo};";
    }
  }
}