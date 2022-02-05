using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IOrderService
  {
    Task<OrderDto> GetById(int id);
    Task<IEnumerable<OrderDto>> GetAll();
    Task<int> Create(CreateOrderDto dto);
    string SaveToCsv(IEnumerable<OrderDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateOrderDto dto);
  }
}
