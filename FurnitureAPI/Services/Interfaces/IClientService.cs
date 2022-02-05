using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public interface IClientService
  {
    Task<ClientDto> GetById(int id);
    Task<IEnumerable<ClientDto>> GetAll();
    Task<int> Create(CreateClientDto dto);
    string SaveToCsv(IEnumerable<ClientDto> components);
    Task Delete(int id);
    Task Update(long id, UpdateClientDto dto);
  }
}
