using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IMaterialService
  {
    Task<MaterialDto> GetById(int id);
    Task<IEnumerable<MaterialDto>> GetAll();
    Task<int> Create(CreateMaterialDto dto);
    string SaveToCsv(IEnumerable<MaterialDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateMaterialDto dto);
  }
}
