using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IEmployeeService
  {
    Task<EmployeeDto> GetById(int id);
    Task<IEnumerable<EmployeeDto>> GetAll();
    Task<int> Create(CreateEmployeeDto dto);
    string SaveToCsv(IEnumerable<EmployeeDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateEmployeeDto dto);
  }
}
