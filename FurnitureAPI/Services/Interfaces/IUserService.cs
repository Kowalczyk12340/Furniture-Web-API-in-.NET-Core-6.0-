using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> GetById(int id);
    Task<IEnumerable<UserDto>> GetAll();
    Task Delete(int id);
    string SaveToCsv(IEnumerable<UserDto> components);
    Task Update(int id, UpdateUserDto dto);
    Task RegisterUser(RegisterDto dto);
    Task<string> GenerateJwt(LoginDto dto);
  }
}