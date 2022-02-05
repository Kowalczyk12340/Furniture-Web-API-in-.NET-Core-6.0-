using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Models;

namespace FurnitureAPI.Services.Interfaces
{
  public class ClientService : IClientService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ClientService> _logger;

    public ClientService(FurnitureDbContext dbContext, IMapper mapper, ILogger<ClientService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateClientDto dto)
    {
      _logger.LogInformation("Creating a new client");
      var client = _mapper.Map<Client>(dto);
      await _dbContext.Clients.AddAsync(client);
      await _dbContext.SaveChangesAsync();
      return client.IdClient;
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<ClientDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<ClientDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateClientDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
