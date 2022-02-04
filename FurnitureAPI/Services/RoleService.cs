using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Services.Interfaces;

namespace FurnitureAPI.Services
{
  public class RoleService : IRoleService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<RoleService> _logger;

    public RoleService(FurnitureDbContext dbContext, IMapper mapper, ILogger<RoleService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public Task<long> Create(CreateRoleDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<RoleDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<RoleDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, UpdateRoleDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
