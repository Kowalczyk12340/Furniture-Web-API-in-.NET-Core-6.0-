using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface ICategoryMaterialService
  {
    Task<CategoryMaterialDto> GetById(int id);
    Task<IEnumerable<CategoryMaterialDto>> GetAll();
    Task<int> Create(CreateCategoryMaterialDto dto);
    string SaveToCsv(IEnumerable<CategoryMaterialDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateCategoryMaterialDto dto);
  }
}
