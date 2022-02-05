using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IOrderStatusService
  {
    Task<StatusOrderDto> GetById(int id);
    Task<IEnumerable<StatusOrderDto>> GetAll();
    Task<int> Create(CreateStatusOrderDto dto);
    string SaveToCsv(IEnumerable<StatusOrderDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateStatusOrderDto dto);
  }
}
