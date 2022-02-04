namespace FurnitureAPI.Dtos.Create
{
  public class CreateEmployeeDto
  {
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeIsDelivered { get; set; }
    public string EmployeeNumberHome { get; set; }
    public string EmployeeEmail { get; set; }
    public int EmployeeSeniority { get; set; }
  }
}
