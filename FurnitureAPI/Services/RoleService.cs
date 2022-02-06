using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Models;
using FurnitureAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    public async Task<int> Create(CreateRoleDto dto)
    {
      _logger.LogInformation("Create new role");
      var role = _mapper.Map<Role>(dto);
      await _dbContext.Roles.AddAsync(role);
      await _dbContext.SaveChangesAsync();
      return role.RoleId;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted role with id: {id}");

      var role = await _dbContext.Roles
        .FirstOrDefaultAsync(x => x.RoleId == id);

      if(role is null)
      {
        throw new NotFoundException("Role is not found");
      }

      _dbContext.Roles.Remove(role);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoleDto>> GetAll()
    {
      _logger.LogInformation("Display all the roles available in the database");
      var roles = await _dbContext.Roles
        .ToListAsync();

      var roleDtos = _mapper.Map<List<RoleDto>>(roles);
      return roleDtos;
    }

    public async Task<RoleDto> GetById(int id)
    {
      _logger.LogInformation($"Display role with id: {id}");
      var role = await _dbContext
        .Roles
        .FirstOrDefaultAsync(x => x.RoleId == id);

      if(role is null)
      {
        throw new NotFoundException("Role is not found");
      }

      var result = _mapper.Map<RoleDto>(role);
      return result;
    }

    public async Task Update(int id, UpdateRoleDto dto)
    {
      _logger.LogInformation($"Edit role with id: {id}");
      var role = await _dbContext
        .Roles
        .FirstOrDefaultAsync(x => x.RoleId == id);

      if(role is null)
      {
        throw new NotFoundException("Role is not found");
      }

      role.RoleName = dto.RoleName;
      await _dbContext.SaveChangesAsync();
    }
  }
}