using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IFurnitureService
  {
    Task<FurnitureDto> GetById(int id);
    Task<IEnumerable<FurnitureDto>> GetAll();
    Task<int> Create(CreateFurnitureDto dto);
    string SaveToCsv(IEnumerable<FurnitureDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateFurnitureDto dto);
  }
}
