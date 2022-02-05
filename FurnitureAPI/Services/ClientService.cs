using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
      _logger.LogWarning($"It will be deleted client with {id}");
      var client = await _dbContext
        .Clients
        .FirstOrDefaultAsync(x => x.IdClient == id);

      if(client is null)
      {
        throw new NotFoundException("Client is not found");
      }

      _dbContext.Clients.Remove(client);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ClientDto>> GetAll()
    {
      _logger.LogInformation("Display all the clients");

      var clients = await _dbContext
        .Clients
        .ToListAsync();

      var clientDtos = _mapper.Map<List<ClientDto>>(clients);
      return clientDtos;
    }

    public async Task<ClientDto> GetById(int id)
    {
      _logger.LogInformation($"Display all the clients with chosen {id}");

      var client = await _dbContext
        .Clients
        .FirstOrDefaultAsync(x => x.IdClient == id);

      if(client is null)
      {
        throw new NotFoundException("Client is not found");
      }

      var result = _mapper.Map<ClientDto>(client);
      return result;
    }

    public string SaveToCsv(IEnumerable<ClientDto> components)
    {
      var headers = "IdClient;ClientName;ClientSurname;ClientPesel;ClientPhone;ClientEmail;ClientTown;ClientStreet;ClientNumberHome;ClientPostPlace;ClientPostalCode;ClientInterested";
      var csv = new StringBuilder(headers);

      csv.Append(Environment.NewLine);

      foreach (var component in components)
      {
        csv.Append(component.GetExportObject());
        csv.Append(Environment.NewLine);
      }
      csv.Append($"Count: {components.Count()}");
      csv.Append(Environment.NewLine);

      return csv.ToString();
    }

    public async Task Update(long id, UpdateClientDto dto)
    {
      _logger.LogInformation($"Edit client with {id}");
      var client = await _dbContext
        .Clients
        .FirstOrDefaultAsync(x => x.IdClient == id);

      if(client is null)
      {
        throw new NotFoundException("Client is not found");
      }

      client.ClientName = dto.ClientName;
      client.ClientSurname = dto.ClientSurname;
      client.ClientPesel = dto.ClientPesel;
      client.ClientPhone = dto.ClientPhone;
      client.ClientEmail = dto.ClientEmail;
      client.ClientTown = dto.ClientTown;
      client.ClientStreet = dto.ClientStreet;
      client.ClientNumberHome = dto.ClientNumberHome;
      client.ClientPostPlace = dto.ClientPostPlace;
      client.ClientPostalCode = dto.ClientPostalCode;
      client.ClientInterested = dto.ClientInterested;

      await _dbContext.SaveChangesAsync();
    }
  }
}