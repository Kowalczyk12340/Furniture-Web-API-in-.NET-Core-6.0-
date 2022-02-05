using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public class EmployeeService : IEmployeeService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(FurnitureDbContext dbContext, IMapper mapper, ILogger<EmployeeService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateEmployeeDto dto)
    {
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<EmployeeDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<EmployeeDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<EmployeeDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateEmployeeDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
