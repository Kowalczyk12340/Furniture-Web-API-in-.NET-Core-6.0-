using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public class MaterialService : IMaterialService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<MaterialService> _logger;

    public MaterialService(FurnitureDbContext dbContext, IMapper mapper, ILogger<MaterialService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateMaterialDto dto)
    {
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<MaterialDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<MaterialDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<MaterialDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateMaterialDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
