using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> GetById(long id);
    Task<IEnumerable<UserDto>> GetAll();
    Task Delete(long id);
    string SaveToCsv(IEnumerable<UserDto> components);
    Task Update(long id, UpdateUserDto dto);
    Task RegisterUser(RegisterDto dto);
    Task<string> GenerateJwt(LoginDto dto);
  }
}
