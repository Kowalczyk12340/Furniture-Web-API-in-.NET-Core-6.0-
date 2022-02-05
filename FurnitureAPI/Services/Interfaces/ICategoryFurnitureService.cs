using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface ICategoryFurnitureService
  {
    Task<CategoryFurnitureDto> GetById(int id);
    Task<IEnumerable<CategoryFurnitureDto>> GetAll();
    Task<int> Create(CreateCategoryFurnitureDto dto);
    string SaveToCsv(IEnumerable<CategoryFurnitureDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateCategoryFurnitureDto dto);
  }
}