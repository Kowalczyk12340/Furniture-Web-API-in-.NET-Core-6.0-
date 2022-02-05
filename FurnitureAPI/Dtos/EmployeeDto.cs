namespace FurnitureAPI.Dtos
{
  public class EmployeeDto
  {
    public int IdEmployee { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeIsDelivered { get; set; }
    public string EmployeeNumberHome { get; set; }
    public string EmployeeEmail { get; set; }
    public int EmployeeSeniority { get; set; }

    public string GetExportObject()
    {
      return $"{IdEmployee};{EmployeeName};{EmployeeSurname};{EmployeeIsDelivered};{EmployeeNumberHome};{EmployeeEmail};{EmployeeSeniority};";
    }
  }
}
