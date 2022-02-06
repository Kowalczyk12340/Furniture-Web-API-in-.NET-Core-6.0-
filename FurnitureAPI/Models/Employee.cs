namespace FurnitureAPI.Models
{
  public class Employee : DomainEntity
  {
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeIsDelivered { get; set; }
    public string EmployeeNumberHome { get; set; }
    public string EmployeeEmail { get; set; }
    public int EmployeeSeniority { get; set; }
  }
}
