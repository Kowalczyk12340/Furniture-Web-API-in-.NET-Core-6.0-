using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public class UserService : IUserService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(FurnitureDbContext dbContext, IMapper mapper, ILogger<UserService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<string> GenerateJwt(LoginDto dto)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<UserDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task RegisterUser(RegisterDto dto)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<UserDto> components)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, UpdateUserDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
