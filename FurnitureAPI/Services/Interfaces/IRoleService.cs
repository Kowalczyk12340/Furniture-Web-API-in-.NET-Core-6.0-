using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IRoleService
  {
    Task<RoleDto> GetById(int id);
    Task<IEnumerable<RoleDto>> GetAll();
    Task<int> Create(CreateRoleDto dto);
    Task Delete(int id);
    Task Update(int id, UpdateRoleDto dto);
  }
}
