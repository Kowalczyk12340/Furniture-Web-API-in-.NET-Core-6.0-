using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IRoleService
  {
    Task<RoleDto> GetById(long id);
    Task<IEnumerable<RoleDto>> GetAll();
    Task<long> Create(CreateRoleDto dto);
    Task Delete(long id);
    Task Update(long id, UpdateRoleDto dto);
  }
}
